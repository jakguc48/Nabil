﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Nabil.Migrations;
using Nabil.Models;
using Nabil.ViewModels;

namespace Nabil.Controllers
{
    public class DishesController : Controller
    {

        #region DishesController Head



        
        private ApplicationDbContext _context;

        public DishesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        #region DishesController Added




        // GET: Dishes
        [Route("Menu")]
        public ActionResult Index()
        {
            var dish = _context.Dishes.ToList();
            if (User.IsInRole(RoleNames.Admin) || User.IsInRole(RoleNames.Manager))
            {
                return View("Index", dish);
            }
            else
            {
                return View("IndexReadOnly", dish);
            }
        }


        [Route("Menu/Dania/{id:regex(\\d)}")]
        public ActionResult Details(int id)
        {
            var dish = _context.Dishes.SingleOrDefault(c => c.Id == id);
            List<Recipe> recipes = (from r in _context.Recipes where r.DishId.Equals(id) select r).ToList();

            List<Ingredient> ingr = new List<Ingredient>();

            Recipe recipe = new Recipe();
            for (int i = 0; i < recipes.Count; i++)
            {
                recipe = recipes[i];
                ingr.Add(_context.Ingredients.SingleOrDefault(m => m.Id == recipe.IngredientId));
            }

            var viewModel = new DishDetailsViewModel
            {
                Dish = dish,
                Ingredients = ingr
            };

            if (dish == null)
            {
                return HttpNotFound();
            }

            return View("Details", viewModel);
        }

        [Authorize(Roles = RoleNames.AdminOrManager)]
        [Route("Menu/Nowe-danie")]
        public ActionResult New()
        {

            ViewBag.IngredientList = new MultiSelectList(_context.Ingredients, "Id", "Name");
            var viewModel = new DishFormViewModel
            {
                FormType = "Nowe danie",
                Dish = new Dish()
            };

            return View("DishForm", viewModel);
        }





        [Authorize(Roles = RoleNames.AdminOrManager)]
        [Route("Menu/Edytuj-danie/{id:regex(\\d)}")]
        public ActionResult Edit(int id)
        {
            ViewBag.IngredientList = new MultiSelectList(_context.Ingredients, "Id", "Name");

            var dish = _context.Dishes.SingleOrDefault(c => c.Id == id);
            if (dish == null)
            {
                return HttpNotFound();
            }

            var viewModel = new DishFormViewModel(dish)
            {
                Dish = dish,
                FormType = "Edytuj danie"
            };

            return View("DishForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.AdminOrManager)]
        public ActionResult Save(Dish dish, HttpPostedFileBase UploadImage, ICollection<int> SelectedIngredientList)
        {
            if (!ModelState.IsValid)
            {
                var typ = dish.Id == 0 ? "Nowe danie" : "Edytuj danie";

                var viewModel = new DishFormViewModel()
                {
                    Dish = dish,
                    FormType = typ
                };
                return View("DishForm", viewModel);
            }

            if (UploadImage != null)
            {
                if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" || UploadImage.ContentType == "image/gif" || UploadImage.ContentType == "image/jpeg")
                {
                    UploadImage.SaveAs(Server.MapPath("/") + "Content/Images/Dishes/" + UploadImage.FileName);
                    dish.ImgUrl = UploadImage.FileName;
                }
                else
                {
                    return RedirectToAction("Index", "Dishes");
                }

            }
            else
            {
                dish.ImgUrl = null;
            }

            if (dish.Id == 0)
            {
                _context.Dishes.Add(dish);

                if (SelectedIngredientList != null)
                {


                    foreach (var ingredientId in SelectedIngredientList)
                    {
                        var obj = new Recipe()
                        {
                            DishId = dish.Id,
                            IngredientId = ingredientId
                        };
                        _context.Recipes.Add(obj);
                    }
                }
            }
            else
            {

                if (SelectedIngredientList != null)
                {

                    List<Recipe> recipes = (from r in _context.Recipes where r.DishId.Equals(dish.Id) select r).ToList();

                    foreach (var rec in recipes)
                    {
                        _context.Recipes.Remove(rec);
                    }

                    foreach (var ingredientId in SelectedIngredientList)
                    {
                        var obj = new Recipe()
                        {
                            DishId = dish.Id,
                            IngredientId = ingredientId
                        };
                        _context.Recipes.Add(obj);
                    }
                }

                var dishInDb = _context.Dishes.Single(c => c.Id == dish.Id);

                dishInDb.Name = dish.Name;
                dishInDb.Kcal = dish.Kcal;
                dishInDb.Size1 = dish.Size1;
                dishInDb.GluteFree = dish.GluteFree;
                dishInDb.Price = dish.Price;
                dishInDb.DishType = dish.DishType;
                dishInDb.Size2 = dish.Size2;
                dishInDb.PriceSmall = dish.PriceSmall;
                dishInDb.Description = dish.Description;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Dishes");
        }



        [Route("Menu/Zmiana-zdjecia/{id:regex(\\d)}")]
        [Authorize(Roles = RoleNames.AdminOrManager)]
        public ActionResult ChangePhoto(int id)
        {
            var dish = _context.Dishes.SingleOrDefault(c => c.Id == id);
            if (dish == null)
            {
                return HttpNotFound();
            }

            var viewModel = new DishFormViewModel(dish)
            {
                Dish = dish,
                FormType = "Zmiana zdjęcia"
            };

            return View("ChangePhoto", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.AdminOrManager)]
        public ActionResult SavePhoto(Dish dish, HttpPostedFileBase UploadImage)
        {

            if (UploadImage != null)
            {
                if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" || UploadImage.ContentType == "image/gif" || UploadImage.ContentType == "image/jpeg")
                {
                    UploadImage.SaveAs(Server.MapPath("/") + "Content/Images/Dishes/" + UploadImage.FileName);
                    dish.ImgUrl = UploadImage.FileName;
                }
                else
                {
                    return RedirectToAction("Index", "Dishes");
                }

            }
            else
            {
                dish.ImgUrl = null;

            }

            var dishInDb = _context.Dishes.Single(c => c.Id == dish.Id);

            dishInDb.ImgUrl = dish.ImgUrl;

            _context.SaveChanges();

            return RedirectToAction("Index", "Dishes");

        }

        [Authorize(Roles = RoleNames.AdminOrManager)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dish dish = _context.Dishes.Find(id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            return View(dish);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.AdminOrManager)]
        public ActionResult DeleteConfirmed(int id)
        {
            Dish dish = _context.Dishes.Find(id);
            _context.Dishes.Remove(dish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion






    }
}
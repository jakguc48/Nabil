using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nabil.Models;
using Nabil.ViewModels;

namespace Nabil.Controllers
{
    public class IngredientsController : Controller
    {
        private ApplicationDbContext _context;

        public IngredientsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Skladniki")]
        public ActionResult Index()
        {
            var ingredients = _context.Ingredients.ToList();
            return View(ingredients);
        }

        [Route("Skladniki/{id:regex(\\d)}")]
        public ActionResult Details(int id)
        {
            var ingredient = _context.Ingredients.SingleOrDefault(c => c.Id == id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        [Route("Skladniki/Nowy-skladnik")]
        public ActionResult New()
        {


            var viewModel = new IngredientFormViewModel
            {
                FormType = "Nowy skladnik",
                Ingredient = new Ingredient()
            };

            return View("IngredientForm", viewModel);
        }



        [Route("Skladniki/edytuj-skladnik/{id:regex(\\d)}")]
        public ActionResult Edit(int id)
        {
            var ingredient = _context.Ingredients.SingleOrDefault(c => c.Id == id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }

            var viewModel = new IngredientFormViewModel(ingredient)
            {
                Ingredient = ingredient,
                FormType = "Edytuj skladnik"
            };

            return View("IngredientForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Ingredient ingredient, HttpPostedFileBase UploadImage)
        {

            if (!ModelState.IsValid)
            {
                var typ = ingredient.Id == 0 ? "Nowy skladnik" : "Edytuj skladnik";

                var viewModel = new IngredientFormViewModel()
                {

                    Ingredient = ingredient,
                    FormType = typ


                };
                return View("IngredientForm", viewModel);
            }

            if (UploadImage != null)
            {
                if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" || UploadImage.ContentType == "image/gif" || UploadImage.ContentType == "image/jpeg")
                {
                    UploadImage.SaveAs(Server.MapPath("/") + "Content/Images/Ingredients/" + UploadImage.FileName);
                    ingredient.ImgUrl = UploadImage.FileName;
                }
                else
                {
                    return RedirectToAction("Index", "Ingredients");
                }

            }
            else
            {
                ingredient.ImgUrl = null;

            }
            
            if (ingredient.Id == 0)
            {
                _context.Ingredients.Add(ingredient);


            }
            else
            {
                var ingredientInDb = _context.Ingredients.Single(c => c.Id == ingredient.Id);


                ingredientInDb.Name = ingredient.Name;


            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Ingredients");
        }



        [Route("Skladniki/Zmiana-zdjecia/{id:regex(\\d)}")]
        public ActionResult ChangePhoto(int id)
        {
            var ingredient = _context.Ingredients.SingleOrDefault(c => c.Id == id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }

            var viewModel = new IngredientFormViewModel(ingredient)
            {
                Ingredient = ingredient,
                FormType = "Zmiana zdjęcia"
            };

            return View("ChangePhoto", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePhoto(Ingredient ingredient, HttpPostedFileBase UploadImage)
        {

            if (UploadImage != null)
            {
                if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" || UploadImage.ContentType == "image/gif" || UploadImage.ContentType == "image/jpeg")
                {
                    UploadImage.SaveAs(Server.MapPath("/") + "Content/Images/Ingredients/" + UploadImage.FileName);
                    ingredient.ImgUrl = UploadImage.FileName;
                }
                else
                {
                    return RedirectToAction("Index", "Ingredients");
                }

            }
            else
            {
                ingredient.ImgUrl = null;

            }

            var ingredientInDb = _context.Ingredients.Single(c => c.Id == ingredient.Id);

            ingredientInDb.ImgUrl = ingredient.ImgUrl;

            _context.SaveChanges();

            return RedirectToAction("Index", "Ingredients");

        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = _context.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = _context.Ingredients.Find(id);
            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }





















    }
}
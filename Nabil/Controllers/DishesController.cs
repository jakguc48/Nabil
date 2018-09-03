using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nabil.Models;
using Nabil.ViewModels;

namespace Nabil.Controllers
{
    public class DishesController : Controller
    {
        private ApplicationDbContext _context;

        public DishesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Dishes
        [Route("Menu")]
        public ActionResult Index()
        {
            var dish = _context.Dishes.ToList();
            return View(dish);
        }


        [Route("Menu/Dania/{id:regex(\\d)}")]
        public ActionResult Details(int id)
        {
            var dish = _context.Dishes.SingleOrDefault(c => c.Id == id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            return View(dish);
        }
        

        [Route("Menu/Nowe-danie")]
        public ActionResult New()
        {
            

            var viewModel = new DishFormViewModel
            {
                FormType = "Nowe danie",
                Dish = new Dish()
            };

            return View("DishForm", viewModel);
        }






        [Route("Menu/Edytuj-danie/{id:regex(\\d)}")]
        public ActionResult Edit(int id)
        {
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
        public ActionResult Save(Dish dish, HttpPostedFileBase UploadImage)
        {

            if (!ModelState.IsValid)
            {
                var typ = dish.Id==0 ? "Nowe danie" : "Edytuj danie";

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
                

            }
            else
            {
                var dishInDb = _context.Dishes.Single(c => c.Id == dish.Id);


                dishInDb.Name = dish.Name;
                dishInDb.Kcal = dish.Kcal;
                dishInDb.Weight = dish.Weight;
                dishInDb.GluteFree = dish.GluteFree;
                dishInDb.Price = dish.Price;
                dishInDb.DishType = dish.DishType;
                //dishInDb.ImgUrl = dish.ImgUrl;

            }
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Dishes");
        }


        
        [Route("Menu/Zmiana-zdjecia/{id:regex(\\d)}")]
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


    }
}
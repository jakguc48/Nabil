using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nabil.Models;

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


        private IEnumerable<Dish> GetDishes()
        {
            return new List<Dish>
            {
                new Dish {Id = 1, Name = "Falafel"},
                new Dish {Id = 2, Name = "Manoush"}
            };
        }
    }
}
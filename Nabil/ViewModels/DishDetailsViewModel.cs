using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nabil.Models;

namespace Nabil.ViewModels
{
    public class DishDetailsViewModel
    {
        public Dish Dish { get; set; }
        //public IEnumerable<Recipe> Recipes { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nabil.Models
{
    public class Recipe
    {
        public Dish Dish { get; set; }

        public Ingredient Ingredient { get; set; }

        [Key, Column(Order = 0)]
        public int DishId { get; set; }

        [Key, Column(Order = 1)]
        public int IngredientId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Nabil.Models;

namespace Nabil.ViewModels
{
    public class IngredientFormViewModel
    {

        public Ingredient Ingredient { get; set; }
        public string FormType { get; set; }



        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Nazwa składnika")]
        public string Name { get; set; }

        [Display(Name = "Obrazek")]
        public string ImgUrl { get; set; }


        public IngredientFormViewModel()
        {
            Id = 0;
        }

        public IngredientFormViewModel(Ingredient ingredient)
        {
            Name = ingredient.Name;
            Id = ingredient.Id;
            ImgUrl = ingredient.ImgUrl;
        }

    }
}
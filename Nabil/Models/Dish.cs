using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nabil.Models
{
    public class Dish
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić nazwę dania")]
        [MaxLength(255)]
        [Display(Name = "Nazwa dania")]
        public string Name { get; set; }

        [Display(Name = "Waga Dania")]
        public short Weight { get; set; }

        [Display(Name = "Kaloryczność/100g")]
        public short Kcal { get; set; }

        [Display(Name = "Czy bezglutenowe?")]
        public bool GluteFree { get; set; }

        [Display(Name = "Zdjęcie")]
        public byte?[] Img { get; set; }

        public Ingredient Ingredient { get; set; }

        public int? IngredientId { get; set; }

    }
}
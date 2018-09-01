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

        [Required(ErrorMessage = "Proszę wprowadzić cenę dania")]
        [Display(Name = "Cena dania")]
        public double Price { get; set; }

        [Display(Name = "Typ dania")]
        public string DishType { get; set; }

        [Display(Name = "Obrazek")]
        public string ImgUrl { get; set; }

    }
}
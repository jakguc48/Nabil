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

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Waga Dania")]
        public short Weight { get; set; }

        [Display(Name = "Kaloryczność")]
        public short Kcal { get; set; }

        [Display(Name = "Zdjęcie")]
        public byte?[] Img { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nabil.Models
{
    public class Ingredient
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Nazwa składnika")]
        public string Name { get; set; }

        [Display(Name = "Zdjęcie")]
        public byte?[] Img { get; set; }
    }
}
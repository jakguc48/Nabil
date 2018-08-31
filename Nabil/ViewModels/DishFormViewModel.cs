﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Nabil.Models;

namespace Nabil.ViewModels
{
    public class DishFormViewModel
    {






        public Dish Dish { get; set; }
        public string FormType { get; set; }


        public int? Id { get; set; }

        [Required]
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

        public DishFormViewModel()
        {
            Id = 0;
        }

        public DishFormViewModel(Dish dish)
        {
            Name = dish.Name;
            Id = dish.Id;
            Weight = dish.Weight;
            Kcal = dish.Kcal;
            GluteFree = dish.GluteFree;
            Img = dish.Img;
        }


    }
}
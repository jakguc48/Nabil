using System;
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
        public Dictionary<string, string> DishTypeDictionary { get; set; }


        public Ingredient Ingredient { get; set; }
        public ICollection<int> SelectedIngredientList { get; set; }
        public ICollection<Recipe> Recipes { get; set; }



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

        [Display(Name = "Obrazek")]
        public string ImgUrl { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić cenę dania")]
        [Display(Name = "Cena dania")]
        public double Price { get; set; }

        [Display(Name = "Typ dania")]
        public string DishType { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Waga dania - mała porcja")]
        public short? WeightSmall { get; set; }

        [Display(Name = "Cena dania - mała porcja")]
        public double? PriceSmall { get; set; }

        public DishFormViewModel()
        {
            Id = 0;

            DishTypeDictionary = new Dictionary<string, string>()
            {
                { "Przystawki", "Przystawki"},
                { "Dania główne", "Dania główne"},
                { "Dodatki", "Dodatki"},
                { "Napoje", "Napoje"},

            };

        }

        public DishFormViewModel(Dish dish)
        {

            DishTypeDictionary = new Dictionary<string, string>()
            {
                { "Przystawki", "Przystawki"},
                { "Dania główne", "Dania główne"},
                { "Dodatki", "Dodatki"},
                { "Napoje", "Napoje"},

            };

            Name = dish.Name;
            Id = dish.Id;
            Weight = dish.Weight;
            Kcal = dish.Kcal;
            GluteFree = dish.GluteFree;
            ImgUrl = dish.ImgUrl;
            Price = dish.Price;
            DishType = dish.DishType;
            Description = dish.Description;
            WeightSmall = dish.WeightSmall;
            PriceSmall = dish.PriceSmall;
        }


    }
}
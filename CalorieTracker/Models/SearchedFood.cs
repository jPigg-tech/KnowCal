using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Models
{
    public class SearchedFood
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Food Name")]
        public string Name { get; set; }

        [Display(Name = "Brand Name")]
        public string  BrandName { get; set; }

        [Display(Name = "Calorie Amount")]
        public int  Calories { get; set; }

        [Display(Name = "Serving Size")]
        public int ServingSize { get; set; }
    }
}

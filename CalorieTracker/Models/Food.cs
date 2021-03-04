using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Food Name")]
        public string FoodName { get; set; }

        [Display(Name = "Calorie Amount")]
        public int CalorieAmmount { get; set; }

        [Display(Name = "Protein Amount")]
        public int ProteinAmount { get; set; }

        [Display(Name = "Fat Amount")]
        public int FatAmount { get; set; }
    }
}

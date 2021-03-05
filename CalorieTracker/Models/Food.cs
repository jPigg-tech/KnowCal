using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Calories")]
        public int CalorieAmmount { get; set; }

        [Display(Name = "Protein (g)")]
        public int ProteinAmount { get; set; }

        [Display(Name = "Fat (g)")]
        public int FatAmount { get; set; }

        [Display(Name = "Serving Size")]
        public int ServingSize { get; set; }

        //[ForeignKey("FoodDiary")]
        //public int FoodDiaryId { get; set; }
        //public FoodDiary FoodDiary { get; set; }
    }
}

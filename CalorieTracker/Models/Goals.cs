using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Models
{
    public class Goals
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "What is your goal weight?")]
        public int? GoalWeight { get; set; }

        public int GoalCalories { get; set; }
        public int WeeklyWeight { get; set; }

        [ForeignKey("Health_Enthusiast")]
        public int HealthEnthusiastId { get; set; }
        public Health_Enthusiast Health_Enthusiast { get; set; }

        //[ForeignKey("FoodDiary")]
        //public int FoodDiaryId { get; set; }
        //public FoodDiary FoodDiary { get; set; }
    }
}

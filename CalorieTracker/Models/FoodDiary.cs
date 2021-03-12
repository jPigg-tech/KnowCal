using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Models
{
    public class FoodDiary
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

        [Display(Name = "Today's Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime TodaysDate { get; set; }

        public int? DailyCaloriesAccumulated { get; set; }

        //private DateTime _timeLogged = DateTime.Now; 
        //public DateTime TimeLogged
        //{
        //    get { return _timeLogged; }
        //    set { _timeLogged = value; }
        //}


        [ForeignKey("Health_Enthusiast")]
        public int HealthEnthusiastId { get; set; }
        public Health_Enthusiast Health_Enthusiast { get; set; }

        [ForeignKey("Meal")]        
        public int MealId { get; set; }
        [Display(Name = "Meal of Day")]
        public Meal Meal { get; set; }

        [NotMapped]
        public SelectList Meals { get; set; }
    }
}

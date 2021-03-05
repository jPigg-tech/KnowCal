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
        public int DailyCaloriesAccumulated { get; set; }
        public List<Food> Breakfast { get; set; }
        public List<Food> Lunch { get; set; }
        public List<Food> Dinner { get; set; }
        public List<Food> Snack { get; set; }
        public Food FoodItem { get; set; }
        public static DateTime TodaysDate { get; }

        //private DateTime _timeLogged = DateTime.Now; 
        //public DateTime TimeLogged
        //{
        //    get { return _timeLogged; }
        //    set { _timeLogged = value; }
        //}


        [ForeignKey("Health_Enthusiast")]
        public int HealthEnthusiastId { get; set; }
        public Health_Enthusiast Health_Enthusiast { get; set; }

        [ForeignKey("Food")]
        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}

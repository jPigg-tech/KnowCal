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
        public Food Food { get; set; }

        private DateTime _timeLogged = DateTime.Now; 
        public DateTime TimeLogged
        {
            get { return _timeLogged; }
            set { _timeLogged = value; }
        }

        [ForeignKey("Health_Enthusiast")]
        public string HealthEnthusiastId { get; set; }
        public Health_Enthusiast Health_Enthusiast { get; set; }

        [ForeignKey("FoodItem")]
        public string FoodId { get; set; }
        public Food FoodItem { get; set; }
    }
}

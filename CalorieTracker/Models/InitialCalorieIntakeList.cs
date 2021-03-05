using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Models
{
    public class InitialCalorieIntakeList
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Eggs")]
        public int eggs = 72;

        [Display(Name = "Chocolate")]
        public int chocolate = 598;

        [Display(Name = "Mixed Baby Lettuce")]
        public int mixedBabyLettuce = 20;

        [Display(Name = "Macaroni And Cheese")]
        public int macAndCheese = 400;

        [Display(Name = "Mayonnaise")]
        public int mayonnaise = 57;

        [Display(Name = "Fast Food")]
        public int fastFood = 836;

        [Display(Name = "Arroz Rojo")]
        public int arrozRojo = 297;


        [ForeignKey("Health_Enthusiast")]
        public int HealthEnthusiastId { get; set; }
        public Health_Enthusiast Health_Enthusiast { get; set; }
    }
}
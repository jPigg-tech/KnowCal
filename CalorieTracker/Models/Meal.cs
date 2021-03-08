using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Models
{
    public class Meal
    {
        [Key]

        public int Id { get; set; }

        [Display(Name = "Meal of Day")]
        public string Name { get; set; }
    }
}

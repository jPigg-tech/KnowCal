using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Models
{
    public class Health_Enthusiast
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "What is your height in inches?")]
        public int Height { get; set; }

        [Display(Name = "What is your current weight?")]
        public int StartingWeight { get; set; }

        public int? InitialCalorieIntake { get; set; }
        // public int InitialCalorieIntake = 0;

        [Display(Name = "What is your sex?")]
        public string Sex { get; set; }

        [Display(Name = "What is your age?")]
        public int Age { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}

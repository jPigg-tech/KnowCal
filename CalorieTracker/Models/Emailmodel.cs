using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Models
{
    public class Emailmodel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Your Email")]
        public string To { get; set; }
        //public string From { get; set; }
        //public string Subject { get; set; }
        //public string Body { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Models
{
    public class NewsLetter
    {
        [Key]
        public int Id { get; set; }

        public bool IsSubscribed { get; set; }

        [ForeignKey("Health_Enthusiast")]
        public int HealthEnthusiastId { get; set; }
        public Health_Enthusiast Health_Enthusiast { get; set; }
    }
}

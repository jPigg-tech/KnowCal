using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Models
{
    public class SearchedFood
    {
        [Key]
        public int Id { get; set; }
    }
}

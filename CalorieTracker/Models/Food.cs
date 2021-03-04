using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int CalorieAmmount { get; set; }
        public int ProteinAmount { get; set; }
        public int FatAmount { get; set; }
    }
}

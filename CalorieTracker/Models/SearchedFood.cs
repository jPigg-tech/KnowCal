﻿using System;
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
        public string Name { get; set; }
        public string  BrandName { get; set; }
        public string  Calories { get; set; }
        public int ServingSize { get; set; }
    }
}

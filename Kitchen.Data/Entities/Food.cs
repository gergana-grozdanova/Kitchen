﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationFramework;

namespace Kitchen.Data.Entities
{
    public  class Food:BaseEntity
    {
        //[ValidNameLength]
       // [ValidFoodName]
        public string Name { get; set; }
        public DateTime CookingTime { get; set; }
        public string Level { get; set; }
    }
}

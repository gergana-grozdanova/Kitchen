using Kitchen.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services.Dtos
{
  public  class FoodDto:BaseDto
    {
        public string Name { get; set; }
        public string Level { get; set; }
    }
}

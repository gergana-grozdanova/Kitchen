using System;
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
        public virtual  string Name { get; set; }
        public virtual string Level { get; set; }
    }
}

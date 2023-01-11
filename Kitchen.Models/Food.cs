using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Models
{
    public  class Food:BaseEntity
    {       
        public virtual  string Name { get; set; }
        public virtual string Level { get; set; }
    }
}

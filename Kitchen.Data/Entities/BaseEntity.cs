﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Data.Entities
{
    public  class BaseEntity
    {
        public virtual string  Id { get; set; }
        public BaseEntity()
        {
            this.Id=Guid.NewGuid().ToString();
        }
    }
}

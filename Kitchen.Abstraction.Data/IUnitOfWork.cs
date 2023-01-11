using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Abstraction.Data
{
  public  interface IUnitOfWork
    {
        void Save();
        void RollBack();
    }
}

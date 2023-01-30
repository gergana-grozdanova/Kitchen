using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Abstraction.Services.Interfaces
{
   public interface IDeleteService
    {
        void Delete(string id);
    }
}

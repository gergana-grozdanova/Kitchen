using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Abstraction.Data
{
    public interface IBeverageRepository : IReadable<Beverage>
    {
    }
}

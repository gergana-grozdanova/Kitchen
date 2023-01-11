using Kitchen.Abstraction.Data;
using Kitchen.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.NHibernate.Data.Repositories
{
   public class FoodRepositoryNHibernate:BaseRepositoryNHibernate<Food>,IFoodRepository
    {
    }
}

using Kitchen.Data.Entities;
using System.Data.Entity;

namespace Kitchen.Data
{
    public class KitchenDbContext:DbContext
    {
       
        public  DbSet<Food> Food { get; set; }
        public KitchenDbContext()
        {

        }
        public KitchenDbContext(string connectionString):base(connectionString)
        {
          
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<KitchenDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}

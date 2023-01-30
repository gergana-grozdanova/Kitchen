using Kitchen.Models;
using System.Data.Entity;

namespace Kitchen.EF.Data
{
    public class KitchenDbContext:DbContext
    {
       
        public  DbSet<Food> Food { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
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

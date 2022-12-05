using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TEST_APP_MVC.Models;

namespace TEST_APP_MVC.Database
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<Order> Order { get; set; }
        public object MenuEntity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        }
    }
    
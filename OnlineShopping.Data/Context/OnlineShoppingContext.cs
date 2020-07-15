using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Entity;

namespace OnlineShopping.Data.Context
{
    public class OnlineShoppingContext : DbContext
    {

        // TODO use unitofWORK

        public readonly string _ConnectionString;
        public OnlineShoppingContext() { }
        public OnlineShoppingContext(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public DbSet<ProductEntiry> Products { get; set; }
        public DbSet<CustomerEntry> Customers { get; set; }
        public DbSet<CustomerRoleEntry> CustomerRoles { get; set; }
        public DbSet<PaymentMethodEntry> PaymentMethods { get; set; }
        public DbSet<OrderEntry> Orders { get; set; }
        public DbSet<OrderItemEntry> OrderItems { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            if (!optionsbuilder.IsConfigured)
            {
                optionsbuilder.UseSqlServer(_ConnectionString);
            }

        }


    }
}

using System.Data.Entity;
using LegacyOrderPortal.Models;

namespace LegacyOrderPortal.DAL
{
    public class LegacyOrderContext : DbContext
    {
        public LegacyOrderContext()
            : base("LegacyOrderContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using CustomerManagement1.Models;

namespace CustomerManagement1.Database
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customers> Customer { get; set; }
    }
}

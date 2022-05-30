using Lcw_GraduationProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lcw_GraduationProject.Persistence.Contexts
{
    public class LcwAPIDbContext : DbContext
    {
        public LcwAPIDbContext(DbContextOptions options) : base(options) //IoC Container'de doldurulacak
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}

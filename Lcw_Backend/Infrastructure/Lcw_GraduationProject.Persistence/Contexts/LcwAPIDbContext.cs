using Lcw_GraduationProject.Domain.Entities;
using Lcw_GraduationProject.Domain.Entities.Common;
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
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Offer> Offers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker:Entity üzerinde  yapılan değişikliklerin yada eklenen verilerin yakalanmasını sağlayan property'dir.

            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch //discard operator: atama yapılmaması gerektiğinde genelde belleği optimum kullanmada işe yarayabilir.
                {
                    EntityState.Added => data.Entity.CreatedTime=DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate=DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(a => a.Order)
                .WithOne(b => b.Product)
                .HasForeignKey<Order>(b => b.ProductId);
        }
    }
}

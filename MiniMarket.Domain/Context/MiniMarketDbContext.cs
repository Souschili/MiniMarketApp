using Microsoft.EntityFrameworkCore;
using MiniMarket.Domain.Entity;
using MiniMarket.Domain.Entity.EntityConfiguration;
using System.Reflection;

namespace MiniMarket.Domain.Context
{
    public class MiniMarketDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<User> Users => Set<User>();

        public MiniMarketDbContext(DbContextOptions<MiniMarketDbContext> options) : base(options) { }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var tracker = base.ChangeTracker.Entries<BaseEntity>();
            foreach (var entity in tracker)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = DateTime.UtcNow;
                    entity.Entity.UpdatedAt = null;
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MiniMarket.Domain.Entity;
using System.Data;

namespace MiniMarket.Domain.Context
{
    public class MiniMarketDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public MiniMarketDbContext(DbContextOptions<MiniMarketDbContext> options) : base(options)
        {
            // без миграций
            Database.EnsureCreated();
        }

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
    }
}

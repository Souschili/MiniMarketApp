using Microsoft.EntityFrameworkCore;
using MiniMarket.Domain.Entity;
using MiniMarket.Domain.Entity.EntityConfiguration;
using System.Reflection;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MiniMarketDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}

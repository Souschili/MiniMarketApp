using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiniMarket.Domain.Entity.EntityConfiguration
{
    class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable(nameof(Cart));

            builder.HasKey(x => x.Id);

            // Настраиваем связь "один ко многим" с каскадным удалением
            builder.HasMany(c => c.Items)  // Указываем, что Cart имеет много Items
                   .WithOne(i => i.Cart)   // Один Item привязан к одной Cart
                   .HasForeignKey(i => i.CartId) // Внешний ключ
                   .OnDelete(DeleteBehavior.Cascade); // При удалении Cart удаляются все Items

        }
    }
}

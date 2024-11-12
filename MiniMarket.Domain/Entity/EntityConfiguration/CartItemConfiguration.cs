using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiniMarket.Domain.Entity.EntityConfiguration
{
    internal class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable(nameof(CartItem));

            builder.HasKey(x => x.Id);

            // Настраиваем связь "многие к одному" с корзиной
            builder.HasOne(i => i.Cart) // Каждый Item принадлежит одной Cart
                   .WithMany(c => c.Items) // Одна Cart содержит много Items
                   .HasForeignKey(i => i.CartId) // Внешний ключ
                   .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление при удалении Cart

            // Пример настройки свойства количества, если это потребуется
            builder.Property(i => i.Quantity)
                   .IsRequired();

            //// Пример настройки цены, если потребуется
            //builder.Property(i => i.Price)
            //       .IsRequired()
            //       .HasColumnType("decimal(18,2)"); // Задание типа данных и точности
        }
    }
}

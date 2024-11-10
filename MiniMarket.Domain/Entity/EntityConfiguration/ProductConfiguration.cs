using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MiniMarket.Domain.Entity.EntityConfiguration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder.Property<int>("Id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)")  // Устанавливаем точность для decimal
            .IsRequired();  // Указываем, что поле обязательно

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Category)
                .HasMaxLength(50)
                .HasDefaultValue("None");

            builder.Property(p => p.Description)
                .HasMaxLength(150)
                .HasDefaultValue("None");

        }
    }
}

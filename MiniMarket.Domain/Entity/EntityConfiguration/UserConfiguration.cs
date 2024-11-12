using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiniMarket.Domain.Entity.EntityConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x=> x.Login)
                .HasMaxLength(50)
                .IsRequired();
            builder.HasData(new[] 
            {
                new User { Id = 1, Login = "Orkhan" },
                new User { Id = 2, Login = "Sarhan" },
                new User { Id = 3, Login = "Oktay" },
            });
        }
    }
}

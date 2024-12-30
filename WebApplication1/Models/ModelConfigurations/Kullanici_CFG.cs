using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.ModelConfigurations
{
    public class Kullanici_CFG : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.Property(x => x.Ad)
                 .HasColumnType("varchar")
                 .HasMaxLength(20)
                 .IsRequired();
            builder.Property(x => x.Soyad)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();
            //bunu yaptıktan sonra geri silmelisin
            Kullanici kullanici = new Kullanici()
            {
                Id = 1,
                Ad = "Super",
                Soyad = "User",
                UserName = "sprAdmn",
                NormalizedUserName = "SPRADMN",
                Email = "super@admin.com",
                NormalizedEmail = "SUPER@admin.com",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };
            PasswordHasher<Kullanici> passwordHasher = new PasswordHasher<Kullanici>();
            kullanici.PasswordHash = passwordHasher.HashPassword(kullanici, "sprAdmn_123");

            builder.HasData(kullanici);
        }
    }
}

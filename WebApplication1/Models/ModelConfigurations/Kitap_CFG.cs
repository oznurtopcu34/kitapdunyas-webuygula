using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.ModelConfigurations
{
    public class Kitap_CFG : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            builder.Property(x => x.KitapAdi)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();         

            builder.Property(x => x.BasimYili)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Fiyat)
              .HasColumnType("money")
              .IsRequired();

            builder.Property(x => x.KitapOzeti)
               .HasColumnType("varchar")
               .HasMaxLength(200)
               .IsRequired();
            builder.Property(x => x.KapakResmi)
               .HasColumnType("varchar")
                .HasMaxLength(200)
               .IsRequired();

        }
    }
}

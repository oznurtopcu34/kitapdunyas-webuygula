using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.ModelConfigurations
{
    public class Yazar_CFG : IEntityTypeConfiguration<Yazar>
    {
        public void Configure(EntityTypeBuilder<Yazar> builder)
        {
            builder.Property(x => x.YazarAdi)
               .HasColumnType("varchar")
               .HasMaxLength(55)
               .IsRequired();
            builder.Property(x => x.Biyografi)
              .HasColumnType("varchar")
              .HasMaxLength(100)
              .IsRequired();
            builder.HasData(
                new Yazar { YazarID=1,YazarAdi="Prof. Ahmet KARADENİZ",Biyografi="Matematikçi"},
                 new Yazar { YazarID = 2, YazarAdi = "M.Turhan Tan", Biyografi="Tarihçi"}

                );
        }
    }
}

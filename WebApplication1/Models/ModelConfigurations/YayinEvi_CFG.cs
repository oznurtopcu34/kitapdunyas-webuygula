using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.ModelConfigurations
{
    public class YayinEvi_CFG : IEntityTypeConfiguration<YayinEvi>
    {
        public void Configure(EntityTypeBuilder<YayinEvi> builder)
        {
            builder.Property(x => x.YayinEviAdi)
                .HasColumnType("varchar")
                .HasMaxLength(55)
                .IsRequired();
            builder.HasData(
                new YayinEvi { YayinEviID=1,YayinEviAdi="Çağlayan "},
                 new YayinEvi { YayinEviID = 2, YayinEviAdi = "Seçkin" },
                    new YayinEvi { YayinEviID = 3, YayinEviAdi = "Kültür" }

                );
        }
    }
}

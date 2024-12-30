using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.ModelConfigurations
{
    public class Kategori_CFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.Property(x => x.KategoriAdi)
                .HasColumnType("varchar")
                .HasMaxLength(55)
                .IsRequired();
            builder.HasData(
                new Kategori { KategoriID=1, KategoriAdi="Akademi"},
                 new Kategori { KategoriID = 2, KategoriAdi = "Tarih" }
                );
        }
    }
}

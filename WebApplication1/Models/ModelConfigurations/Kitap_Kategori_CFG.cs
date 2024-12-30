using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.ModelConfigurations
{
    public class Kitap_Kategori_CFG : IEntityTypeConfiguration<Kitap_Kategori>
    {
        public void Configure(EntityTypeBuilder<Kitap_Kategori> builder)
        {
           
        }
    }
}

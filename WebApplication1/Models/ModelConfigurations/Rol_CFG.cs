using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models.ModelConfigurations
{
    public class Rol_CFG : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasData(
                 new Rol { Id = 1, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
                 new Rol { Id = 2, Name = "Uye", NormalizedName = "Uye", ConcurrencyStamp = Guid.NewGuid().ToString() }
                 );
        }
    }
}

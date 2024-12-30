using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class KitapDBContext :IdentityDbContext<Kullanici,Rol,int>
    {
        public KitapDBContext()
        {
            
        }
        public KitapDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kitap_Kategori> Kitaplar_Kategoriler { get; set; }
        public DbSet<YayinEvi> YayinEvleri { get; set; }
        public DbSet<Yazar>Yazarlar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 });

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

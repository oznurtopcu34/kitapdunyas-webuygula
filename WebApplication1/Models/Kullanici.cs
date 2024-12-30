using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace WebApplication1.Models
{
    public class Kullanici:IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}

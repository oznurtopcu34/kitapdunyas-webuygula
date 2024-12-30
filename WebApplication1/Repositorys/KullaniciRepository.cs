using WebApplication1.Abstract;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositorys
{
    public class KullaniciRepository : BaseRepository<Kullanici>
    {
        public KullaniciRepository(KitapDBContext dbContext) : base(dbContext)
        {
        }
    }
}

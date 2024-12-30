using WebApplication1.Abstract;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositorys
{
    public class KategoriRepository : BaseRepository<Kategori>
    {
        public KategoriRepository(KitapDBContext dbContext) : base(dbContext)
        {
        }
    }
}

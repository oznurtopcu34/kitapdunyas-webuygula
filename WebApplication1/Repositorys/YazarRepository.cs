using WebApplication1.Abstract;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositorys
{
    public class YazarRepository : BaseRepository<Yazar>
    {
        public YazarRepository(KitapDBContext dbContext) : base(dbContext)
        {
        }
    }
}

using WebApplication1.Abstract;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositorys
{
    public class YayinEviRepository : BaseRepository<YayinEvi>
    {
        public YayinEviRepository(KitapDBContext dbContext) : base(dbContext)
        {
        }
    }
}

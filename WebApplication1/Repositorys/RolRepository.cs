using WebApplication1.Abstract;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositorys
{
    public class RolRepository : BaseRepository<Rol>
    {
        public RolRepository(KitapDBContext dbContext) : base(dbContext)
        {
        }
    }
}

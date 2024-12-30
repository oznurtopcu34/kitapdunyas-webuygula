
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Abstract
{
    public class BaseRepository<TEntity> : ICRUD<TEntity> where TEntity : class
    {
       
        protected readonly KitapDBContext _dbContext;
        protected readonly DbSet<TEntity> _tables;

        public BaseRepository(KitapDBContext dbContext)
        {
            _dbContext = dbContext;
            _tables = _dbContext.Set<TEntity>();
        }

    
        public TEntity Bul(int id)
        {
            return _tables.Find(id);
        }

        public void Ekle(TEntity entity)
        {
            _tables.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Guncelle(TEntity entity)
        {
            _tables.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Sil(int id)
        {
            _tables.Remove(Bul(id));
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> TumunuGetir()
        {
            return _tables.ToList();
        }
    }
}

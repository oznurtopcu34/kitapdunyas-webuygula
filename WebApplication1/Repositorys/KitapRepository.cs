using Microsoft.EntityFrameworkCore;
using WebApplication1.Abstract;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositorys
{
    public class KitapRepository : BaseRepository<Kitap>
    {
        public KitapRepository(KitapDBContext dbContext) : base(dbContext)
        {
        }
    
    
        public void Guncelle(Kitap kitap)
        {
            _dbContext.Kitaplar.Update(kitap);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Kitap> TumunuGetir()
        {
            return _dbContext.Kitaplar
                             .Include(x => x.Yazar)
                             .Include(x => x.YayinEvi)
                             .Include(x => x.Kitaplar_Kategoriler) // Kategorileri de dahil etme
                             .ToList();
        }

    
        public void Sil(int id)
        {
            var kitap = _dbContext.Kitaplar.Find(id);
            if (kitap != null)
            {
                _dbContext.Kitaplar.Remove(kitap);
                _dbContext.SaveChanges();
            }
        }
    }
}

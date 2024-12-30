using Microsoft.EntityFrameworkCore;
using WebApplication1.Abstract;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositorys
{
    public class Kitap_KategoriRepository : BaseRepository<Kitap_Kategori>
    {
        public Kitap_KategoriRepository(KitapDBContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Kitap_Kategori> KategoriTumunuGetir()
        {
            return _dbContext.Kitaplar_Kategoriler
                             .Include(x => x.Kitap)      // Kitap ilişkisini dahil et
                             .Include(x => x.Kategori)   // Kategori ilişkisini dahil et
                             .ToList();
        }
        public void Ekle(Kitap_Kategori kitapKategori)
        {
            _dbContext.Kitaplar_Kategoriler.Add(kitapKategori);
            _dbContext.SaveChanges();
        }

        // Belirli bir kitaba ait tüm kategorileri getir
        public IEnumerable<Kitap_Kategori> KategorileriGetir(int kitapId)
        {
            return _dbContext.Kitaplar_Kategoriler.Where(x => x.KitapID == kitapId).ToList();
        }

        // Kitap-Kategori ilişkisini sil
        public void Sil(Kitap_Kategori kitapKategori)
        {
            _dbContext.Kitaplar_Kategoriler.Remove(kitapKategori);
            _dbContext.SaveChanges();
        }
    }
}

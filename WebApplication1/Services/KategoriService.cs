using WebApplication1.Models;
using WebApplication1.Repositorys;

namespace WebApplication1.Services
{
    public class KategoriService
    {
        private readonly KategoriRepository _kategoriRepository;

        public KategoriService(KategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }

        // Tüm kategorileri getir
        public IEnumerable<Kategori> TumKategorileriGetir()
        {
            return _kategoriRepository.TumunuGetir();
        }

        // ID'ye göre bir kategori getir
        public Kategori Getir(int id)
        {
            return _kategoriRepository.Bul(id);
        }

        // Yeni kategori ekle
        public void Ekle(Kategori kategori)
        {
            _kategoriRepository.Ekle(kategori);
        }

        // Mevcut bir kategoriyi güncelle
        public void Guncelle(Kategori kategori)
        {
            _kategoriRepository.Guncelle(kategori);
        }

        // Kategori sil
        public void Sil(int id)
        {
            _kategoriRepository.Sil(id);
        }
    }
}

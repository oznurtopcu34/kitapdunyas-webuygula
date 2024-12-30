using WebApplication1.Models;
using WebApplication1.Repositorys;

namespace WebApplication1.Services
{
    public class YayinEviService
    {
        private readonly YayinEviRepository _yayinEviRepository;

        public YayinEviService(YayinEviRepository yayinEviRepository)
        {
            _yayinEviRepository = yayinEviRepository;
        }

        // Tüm yayınevlerini getir
        public IEnumerable<YayinEvi> TumYayinEvleriniGetir()
        {
            return _yayinEviRepository.TumunuGetir();
        }

        // ID'ye göre bir yayınevi getir
        public YayinEvi Getir(int id)
        {
            return _yayinEviRepository.Bul(id);
        }

        // Yeni yayınevi ekle
        public void Ekle(YayinEvi yayinEvi)
        {
            _yayinEviRepository.Ekle(yayinEvi);
        }

        // Mevcut bir yayınevini güncelle
        public void Guncelle(YayinEvi yayinEvi)
        {
            _yayinEviRepository.Guncelle(yayinEvi);
        }

        // Yayınevi sil
        public void Sil(int id)
        {
            _yayinEviRepository.Sil(id);
        }
    }
}

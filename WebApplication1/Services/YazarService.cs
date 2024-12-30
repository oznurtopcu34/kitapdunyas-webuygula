using WebApplication1.Models;
using WebApplication1.Repositorys;

namespace WebApplication1.Services
{
    public class YazarService
    {

      
        private readonly YazarRepository _yazarRepository;

        public YazarService(YazarRepository yazarRepository)
        {
            _yazarRepository = yazarRepository;
        }

    
        // Tüm yazarları getir
        public IEnumerable<Yazar> TumYazarlariGetir()
        {
            return _yazarRepository.TumunuGetir();
        }

        // ID'ye göre bir yazar getir
        public Yazar Getir(int id)
        {
            return _yazarRepository.Bul(id);
        }

        // Yeni yazar ekle
        public void Ekle(Yazar yazar)
        {
            _yazarRepository.Ekle(yazar);
        }

        // Mevcut bir yazarı güncelle
        public void Guncelle(Yazar yazar)
        {
            _yazarRepository.Guncelle(yazar);
        }

        // Yazar sil
        public void Sil(int id)
        {
            _yazarRepository.Sil(id);
        }
    }
}

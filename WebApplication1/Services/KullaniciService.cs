using WebApplication1.Models;
using WebApplication1.Repositorys;

namespace WebApplication1.Services
{
    public class KullaniciService
    {
        private readonly KullaniciRepository _kullaniciRepository;

        public KullaniciService(KullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        // Tüm kullanıcıları getir
        public IEnumerable<Kullanici> TumKullanicilariGetir()
        {
            return _kullaniciRepository.TumunuGetir();
        }

        // ID'ye göre bir kullanıcı getir
        public Kullanici Getir(int id)
        {
            return _kullaniciRepository.Bul(id);
        }

        // Yeni kullanıcı ekle
        public void Ekle(Kullanici kullanici)
        {
            _kullaniciRepository.Ekle(kullanici);
        }

        // Mevcut bir kullanıcıyı güncelle
        public void Guncelle(Kullanici kullanici)
        {
            _kullaniciRepository.Guncelle(kullanici);
        }

        // Kullanıcı sil
        public void Sil(int id)
        {
            _kullaniciRepository.Sil(id);
        }
    }
}

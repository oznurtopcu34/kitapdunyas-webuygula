using WebApplication1.Models;
using WebApplication1.Repositorys;

namespace WebApplication1.Services
{
    public class Kitap_KategoriService
    {
        private readonly Kitap_KategoriRepository _kitapKategoriRepository;
        private readonly KitapRepository _kitapRepository;
        public Kitap_KategoriService(Kitap_KategoriRepository kitapKategoriRepository)
        {
            _kitapKategoriRepository = kitapKategoriRepository;
        }

      
        public void KategoriEkle(int kitapId, int kategoriId)
        {
            var yeniKayit = new Kitap_Kategori
            {
                KitapID = kitapId,
                KategoriID = kategoriId
            };

            _kitapKategoriRepository.Ekle(yeniKayit);
        }

        // Belirli bir kitaptan kategori kaldır
        public void KategorileriSil(int kitapId)
        {
            var mevcutKategoriler = _kitapKategoriRepository.KategorileriGetir(kitapId);
            foreach (var kategori in mevcutKategoriler)
            {
                _kitapKategoriRepository.Sil(kategori);
            }
        }


    }
}


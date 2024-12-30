using WebApplication1.Areas.AdminPanel.Models.ViewModel;
using WebApplication1.Models;
using WebApplication1.Repositorys;

namespace WebApplication1.Services
{
    public class KitapService
    {
        private readonly KitapRepository _kitapRepository;

        public KitapService(KitapRepository kitapRepository)
        {
            _kitapRepository = kitapRepository;
        }

        // Tüm kitapları getir
        public IEnumerable<Kitap> TumKitaplariGetir()
        {
            return _kitapRepository.TumunuGetir();
        }

        // ID'ye göre bir kitap getir

        public Kitap Getir(int id)
        {
            return _kitapRepository.Bul(id);
        }

        // Yeni kitap ekle
        public Kitap Ekle(Kitap_VM kitapVm, int kullaniciId)
        {
            var yeniKitap = new Kitap
            {
                KitapAdi = kitapVm.KitapAdi,
                BasimYili = kitapVm.BasimYili,
                Fiyat = kitapVm.Fiyat,
                KitapOzeti = kitapVm.KitapOzeti,
                YazarID = kitapVm.YazarID,
                YayinEviID = kitapVm.YayinEviID,
                KullaniciID = kullaniciId
            };

            // Resim dosyasını kaydetme
            if (kitapVm.KapakResmi != null && kitapVm.KapakResmi.Length > 0)
            {
                string fileName = kitapVm.KapakResmi.FileName;
                string resimKayit = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Resimler");
           
                string filePath = Path.Combine(resimKayit, fileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    kitapVm.KapakResmi.CopyTo(fs);
                }

                yeniKitap.KapakResmi = fileName;
            }
         
            // Yeni kitabı veritabanına ekleme
            _kitapRepository.Ekle(yeniKitap);

            return yeniKitap;
        }
        //  Kitap güncelle
        public void Guncelle(Kitap kitap)
        {
            _kitapRepository.Guncelle(kitap);
        }

        // Kitap sil

        public void Sil(int id)
        {
            _kitapRepository.Sil(id);
        }
    }
}

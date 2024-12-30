using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using WebApplication1.Areas.AdminPanel.Models.ViewModel;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly KitapService _kitapService;
        private readonly YazarService _yazarService;
        private readonly KullaniciService _kullaniciService;
        private readonly KategoriService _kategoriService;
        private readonly YayinEviService _yayinEviService;
        private readonly Kitap_KategoriService _kitapKategoriService;

        public HomeController(UserManager<Kullanici> userManager, KitapService kitapService, YazarService yazarService, KullaniciService kullaniciService, KategoriService kategoriService, YayinEviService yayinEviService, Kitap_KategoriService kitapKategoriService)
        {
            _userManager = userManager;
            _kitapService = kitapService;
            _yazarService = yazarService;
            _kullaniciService = kullaniciService;
            _kategoriService = kategoriService;
            _yayinEviService = yayinEviService;
            _kitapKategoriService = kitapKategoriService;
        }





        public IActionResult Index()
        {
            return View();
        }

        // 1. Tüm Kitapları Listeleme
      
        public IActionResult TumKitaplar()
        {
            ViewBag.Kategoriler = new SelectList(_kategoriService.TumKategorileriGetir(), "KategoriID", "KategoriAdi");
            var kitaplar = _kitapService.TumKitaplariGetir();
            return View(kitaplar);
        }

        //Kitap ile ilgili işlemler
        public IActionResult KitapIslemleri()
        {
            ViewBag.Kategoriler = new SelectList(_kategoriService.TumKategorileriGetir(), "KategoriID", "KategoriAdi");
            var kitaplar = _kitapService.TumKitaplariGetir();
            return View(kitaplar);
        }


        // 2. Yazara Göre Kitapları Listeleme
        public IActionResult YazaraGoreKitaplar(int yazarId)
        {
            var kitaplar = _kitapService.TumKitaplariGetir()
                                        .Where(k => k.YazarID == yazarId)
                                        .ToList();
            var yazar = _yazarService.Getir(yazarId);

            ViewBag.YazarAdi = yazar.YazarAdi;

         
            ViewBag.Yazarlar = new SelectList(_yazarService.TumYazarlariGetir(), "YazarID", "YazarAdi");

            return View(kitaplar);
        }
        // 3. En Pahalıdan En Ucuza İlk 10 Kitap
        public IActionResult EnPahali10Kitap()
        {
            var kitaplar = _kitapService.TumKitaplariGetir()
                                        .OrderByDescending(k => k.Fiyat)
                                        .Take(10);
            return View(kitaplar);
        }

      

        // 5. Tüm Üyeleri Listeleme
        public IActionResult TumUyeler()
        {
            var kullanicilar = _kullaniciService.TumKullanicilariGetir();
            return View(kullanicilar);
        }



        // Kitap Ekleme
        public IActionResult KitapEkle()
        {
            ViewBag.Yazarlar = new SelectList(_yazarService.TumYazarlariGetir(), "YazarID", "YazarAdi");
            ViewBag.Kategoriler = new SelectList(_kategoriService.TumKategorileriGetir(), "KategoriID", "KategoriAdi");
            ViewBag.YayinEvleri = new SelectList(_yayinEviService.TumYayinEvleriniGetir(), "YayinEviID", "YayinEviAdi");

            return View();
        }

        [HttpPost]
        public IActionResult KitapEkle(Kitap_VM kitapVm, List<int> kategoriID)
        {
            if (ModelState.IsValid)
            {
                // Kitabı kaydet ve Kitap nesnesini al
                var yeniKitap = _kitapService.Ekle(kitapVm, GetUserID()); // Kullanıcı ID'yi gönderdik

                // Seçilen kategorileri yeni eklenen kitaba ekleme
                foreach (var kategoriId in kategoriID)
                {
                    _kitapKategoriService.KategoriEkle(yeniKitap.KitapID, kategoriId);
                }
                return RedirectToAction("Index");
            }

            // Hata durumunda ViewBag verilerini yeniden yükleyip sayfayı geri döndür
            ViewBag.Yazarlar = _yazarService.TumYazarlariGetir().ToList();
            ViewBag.Kategoriler = _kategoriService.TumKategorileriGetir().ToList();
            ViewBag.YayinEvleri = _yayinEviService.TumYayinEvleriniGetir().ToList();
            return View(kitapVm);
        }
        public IActionResult KitapGuncelle(int id)
        {
            var kitap = _kitapService.Getir(id);
            if (kitap == null)
            {
                return NotFound();
            }

            // Kitap modelini Kitap_VM modeline dönüştür
            var kitapVm = new Kitap_VM
            {
                KitapID = kitap.KitapID,
                KitapAdi = kitap.KitapAdi,
                BasimYili = kitap.BasimYili,
                Fiyat = kitap.Fiyat,
                KitapOzeti = kitap.KitapOzeti,
                YazarID = kitap.YazarID,
                YayinEviID = kitap.YayinEviID,
                KullaniciID = kitap.KullaniciID,
                KapakResmi = null // Kapak resmi bilgisi ViewModel'de IFormFile olduğundan burada null bırakıldı
            };
          

            ViewBag.Yazarlar = new SelectList(_yazarService.TumYazarlariGetir(), "YazarID", "YazarAdi");
            ViewBag.Kategoriler = new SelectList(_kategoriService.TumKategorileriGetir(), "KategoriID", "KategoriAdi");
            ViewBag.YayinEvleri = new SelectList(_yayinEviService.TumYayinEvleriniGetir(), "YayinEviID", "YayinEviAdi");
            return View(kitapVm);
        }

        [HttpPost]
        public IActionResult KitapGuncelle(Kitap_VM kitapVm, List<int> kategoriID)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User); // Kullanıcı kimliğini alın

                // Kitap_VM modelini Kitap modeline dönüştür
                var kitap = new Kitap
                {
                    KitapID = kitapVm.KitapID,
                    KitapAdi = kitapVm.KitapAdi,
                    BasimYili = kitapVm.BasimYili,
                    Fiyat = kitapVm.Fiyat,
                    KitapOzeti = kitapVm.KitapOzeti,
                    YazarID = kitapVm.YazarID,
                    YayinEviID = kitapVm.YayinEviID,
                    KullaniciID = GetUserID(), // Geçerli kullanıcı kimliğini kullanın
                    KapakResmi = kitapVm.KapakResmi.FileName
                };

                // Eğer resim dosyası yüklüyse, dosyayı kaydedelim
                if (kitapVm.KapakResmi != null && kitapVm.KapakResmi.Length > 0)
                {
                      string fileName = kitapVm.KapakResmi.FileName;
                        string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Resimler");
                        

                        string filePath = Path.Combine(rootPath, fileName);
                        using (var fs = new FileStream(filePath, FileMode.Create))
                        {
                            kitapVm.KapakResmi.CopyTo(fs);
                        }

                        kitap.KapakResmi = fileName;
                    
                   
                }
                foreach (var kategoriId in kategoriID)
                {
                    _kitapKategoriService.KategoriEkle(kitap.KitapID, kategoriId);
                }

                _kitapService.Guncelle(kitap);
                return RedirectToAction("Index");
            }

            ViewBag.Yazarlar = new SelectList(_yazarService.TumYazarlariGetir(), "YazarID", "YazarAdi");
            ViewBag.Kategoriler = new SelectList(_kategoriService.TumKategorileriGetir(), "KategoriID", "KategoriAdi");
            ViewBag.YayinEvleri = new SelectList(_yayinEviService.TumYayinEvleriniGetir(), "YayinEviID", "YayinEviAdi");
            return View(kitapVm);
        }



        //  Kitap Silme 
        public IActionResult KitapSil(int id)
        {
            var kitap = _kitapService.Getir(id);
         
            ViewBag.Yazarlar = _yazarService.TumYazarlariGetir().ToList();
            ViewBag.Kategoriler = _kategoriService.TumKategorileriGetir().ToList();
            ViewBag.YayinEvleri = _yayinEviService.TumYayinEvleriniGetir().ToList();
            return View(kitap);
        }

        // POST: Kitap Silme
        [HttpPost, ActionName("KitapSil")]
        public IActionResult KitapSilPost(int id)
        {
            _kitapService.Sil(id);
            //TempData["SuccessMessage"] = "Kitap başarıyla silindi.";
            return RedirectToAction("KitapIslemleri");
        }


        // Yazar Ekleme
        public IActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YazarEkle(Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                _yazarService.Ekle(yazar);
                return RedirectToAction("Index");
            }
            return View(yazar);
        }

        // Kategori Ekleme
        public IActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KategoriEkle(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _kategoriService.Ekle(kategori);
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        // Yayınevi Ekleme
        public IActionResult YayinEviEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YayinEviEkle(YayinEvi yayinEvi)
        {
            if (ModelState.IsValid)
            {
                _yayinEviService.Ekle(yayinEvi);
                return RedirectToAction("Index");
            }
            return View(yayinEvi);
        }
        private int GetUserID()
        {
            return int.Parse(_userManager.GetUserId(User));
        }
    }
}

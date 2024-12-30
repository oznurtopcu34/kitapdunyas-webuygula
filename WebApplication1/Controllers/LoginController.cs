using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;

        public LoginController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Login_VM login)
        {
            if (ModelState.IsValid)
            {
                var kullanici = await _userManager.FindByNameAsync(login.UserName);
                if (kullanici != null)
                {
                    bool sifreDogruMU = await _userManager.CheckPasswordAsync(kullanici, login.Password);
                    if (sifreDogruMU)
                    {
                        await _signInManager.SignInAsync(kullanici, false);
                        return RedirectToAction("Index", "Home");                    
                    }
                    ModelState.AddModelError("HATA", "Kullanici adı veya sifre hatalı");
                    return View();
                }
            }
            return View();
        }
        public IActionResult KullaniciEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciEkle(KullaniciEkle_VM kullanici)
        {
            if (ModelState.IsValid)
            {
                Kullanici yeniKullanici = new Kullanici();
                yeniKullanici.Ad = kullanici.Ad;
                yeniKullanici.Soyad = kullanici.Soyad;
                yeniKullanici.UserName = kullanici.KullaniciAdi;
                yeniKullanici.Email = kullanici.Eposta;

                var result = await _userManager.CreateAsync(yeniKullanici, kullanici.Sifre);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(yeniKullanici, "Uye");  
                    return RedirectToAction("Index");
                }


            }
            return View();
        }

        public async Task<IActionResult> Cikis()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }



    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Areas.UyePanel
{
    [Area("UyePanel")]
    [Authorize(Roles = "Uye")]
    public class HomeController : Controller
    {
        private readonly KitapService _kitapService;

        public HomeController(KitapService kitapService)
        {
            _kitapService = kitapService;
        }

        public IActionResult Index()
        {
            var kitaplar = _kitapService.TumKitaplariGetir();
            return View(kitaplar);
           
        }
       
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels
{
    public class KullaniciEkle_VM
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        [EmailAddress(ErrorMessage = "Eposta hatalı...")]
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        [Compare("Sifre", ErrorMessage = "Sifreler aynı degil...")]
        public string SifreTekrar { get; set; }
    }
}

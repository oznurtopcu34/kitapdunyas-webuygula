namespace WebApplication1.Areas.AdminPanel.Models.ViewModel
{
    public class Kitap_VM
    {
        public int KitapID { get; set; }
        public string KitapAdi { get; set; }
        public int BasimYili { get; set; }
        public double Fiyat { get; set; }
        public string KitapOzeti { get; set; }
        public IFormFile? KapakResmi { get; set; }
        public int YazarID { get; set; }
        public int KategoriID { get; set; }
        public int YayinEviID { get; set; }
        public int KullaniciID { get; set; }
    }
}

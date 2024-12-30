namespace WebApplication1.Models
{
    public class Kitap
    {
        public int KitapID { get; set; }
        public string KitapAdi { get; set; }       
        public int BasimYili { get; set; }
        public double Fiyat {  get; set; }       
        public string KitapOzeti { get; set; }
        public string? KapakResmi { get; set; }
        public int YazarID { get; set; }
        public int YayinEviID { get; set; }
        public int KullaniciID { get; set; }


        // Navigation properties
        public Kullanici? Kullanici { get; set; }
        public Yazar? Yazar { get; set; }
        public YayinEvi? YayinEvi { get; set; }
        public ICollection<Kitap_Kategori>? Kitaplar_Kategoriler { get; set; } // Çoktan çoğa ilişki
    }
}

namespace WebApplication1.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }

        // Navigation properties
        public ICollection<Kitap_Kategori>? Kitaplar_Kategoriler { get; set; } // Çoktan çoğa ilişki
    }
}

namespace WebApplication1.Models
{
    public class Yazar
    {
        public int YazarID { get; set; }
        public string YazarAdi { get; set; }
        public string Biyografi { get; set; }

        // Navigation properties
        public ICollection<Kitap>? Kitaplar { get; set; } // Bir yazar birden fazla kitap yazabilir
    }
}

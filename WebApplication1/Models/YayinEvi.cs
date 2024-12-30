namespace WebApplication1.Models
{
    public class YayinEvi
    {
        public int YayinEviID { get; set; }
        public string YayinEviAdi { get; set; }       

        // Navigation properties
        public ICollection<Kitap>? Kitaplar { get; set; } // Bir yayınevi birden fazla kitap yayınlayabilir
    }
}

namespace WebApplication1.Models
{
    public class Kitap_Kategori
    {
        public int ID { get; set; }
        public int KitapID { get; set; }
        public int KategoriID { get; set; }

        // Navigation properties
        public Kitap? Kitap { get; set; }
        public Kategori? Kategori { get; set; }
    }
}

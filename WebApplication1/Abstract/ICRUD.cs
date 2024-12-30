namespace WebApplication1.Abstract
{
    public interface ICRUD<TEntity> where TEntity : class
    {
        void Ekle(TEntity entity);
        void Guncelle(TEntity entity);
        void Sil(int id);
        IEnumerable<TEntity> TumunuGetir();
        TEntity Bul(int id);
    }
}

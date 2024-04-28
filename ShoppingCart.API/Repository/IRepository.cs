namespace ShoppingCart.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int Id);

        T Add(T entity);
        T Update(T entity, int Id);
        T Delete(T entity, int Id);
    }
}
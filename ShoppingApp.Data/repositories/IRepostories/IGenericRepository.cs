namespace shoppingApp.Data.repositories.IRepostories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<IEnumerable<T>> All();
        Task<T?> Get(Guid Id);
        void Delete(T entity);
    }
}
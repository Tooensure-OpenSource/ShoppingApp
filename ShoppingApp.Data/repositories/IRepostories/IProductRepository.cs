using shoppingApp.Data.DbSet;

namespace shoppingApp.Data.repositories.IRepostories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> ProductsForBusiness(Guid userId, Guid businessId);
        Task<Product> Get(Guid userId, Guid businessId, Guid ProductId);
        Task<IEnumerable<Product>> ProductsForUser(Guid userId);
        decimal CaculateOrderCost(List<Product> products);
    }
}
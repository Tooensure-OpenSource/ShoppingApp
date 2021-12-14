using shoppingApp.Data.DbSet;

namespace shoppingApp.Data.repositories.IRepostories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> IsProductOfBusiness(Guid productId, Guid businessId);
        Task<bool> IsUserOfBusiness(Guid userId, Guid businessId);
        decimal CaculateOrderCost(List<Product> products);
        Task<bool> Exist(Guid productId);
    }
}
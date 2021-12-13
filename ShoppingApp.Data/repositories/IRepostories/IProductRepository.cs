using shoppingApp.Data.DbSet;

namespace shoppingApp.Data.repositories.IRepostories
{
    public interface IProductRepository : IGenericRepository<Product>
    {

        decimal CaculateOrderCost(List<Product> products);
        Task<bool> Exist(Guid productId);
    }
}
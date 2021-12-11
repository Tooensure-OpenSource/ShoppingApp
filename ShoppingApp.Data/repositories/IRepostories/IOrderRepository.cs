using shoppingApp.Data.DbSet;

namespace shoppingApp.Data.repositories.IRepostories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> All(Guid userId);
        Task<IEnumerable<Order>> Get(Guid userId, Guid businessId);
        Task<Order> Get(Guid userId, Guid businessId, Guid OrderId);
        decimal CaculateOrderCost(List<Product> products);
    }
}
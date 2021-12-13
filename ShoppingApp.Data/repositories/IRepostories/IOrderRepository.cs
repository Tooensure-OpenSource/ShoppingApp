using shoppingApp.Data.DbSet;

namespace shoppingApp.Data.repositories.IRepostories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        decimal CaculateOrderCost(List<Product> products);
    }
}
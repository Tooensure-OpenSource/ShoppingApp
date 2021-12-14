using Microsoft.EntityFrameworkCore;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.repositories.IRepostories;

namespace shoppingApp.Data.repositories.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }

        public decimal CaculateOrderCost(List<Product> products)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Delete(Order entity)
        {
            throw new NotImplementedException();
        }

    }
}
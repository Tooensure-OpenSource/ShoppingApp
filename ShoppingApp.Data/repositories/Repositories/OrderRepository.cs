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
        public async override Task<IEnumerable<Order>> All()
        {
            return await _dbSet
            .Include(x => x.OrderItems)
            .ToListAsync();
        }
        
        public async override Task<Order?> Get(Guid orderId)
        {
            return await _dbSet
            .Include(x => x.OrderItems)
            .FirstOrDefaultAsync();
        }

        public decimal CaculateOrderCost(List<Product> products)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

    }
}
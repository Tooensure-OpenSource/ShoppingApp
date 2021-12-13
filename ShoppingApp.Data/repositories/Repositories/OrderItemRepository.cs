using Microsoft.EntityFrameworkCore;
using shoppingApp.Data.repositories.Repositories;
using ShoppingApp.Data.DbSet;
using ShoppingApp.Data.repositories.IRepostories;

namespace ShoppingApp.Data.repositories.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DbContext context) : base(context)
        {
        }


        public async override Task<IEnumerable<OrderItem>> All()
        {
            return await _dbSet
            .Include(x => x.Product)
            .ToListAsync();
        }

        public override Task<bool> Delete(OrderItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
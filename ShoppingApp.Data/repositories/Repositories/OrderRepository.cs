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


        public async Task<IEnumerable<Order>> Get(Guid userId, Guid businessId)
        {
            return await _dbSet
            .Include(x => x.OrderItems)
            .Include(x => x.Business)
            .Where(x => x.BuisnessId == businessId)
            .ToListAsync();
        }


        ///<summary>
        /// Fact: passing useful information like userId, then the business id, 
        /// followed by the order Id will in fact return a specfic order.
        ///</summary>

    }
}
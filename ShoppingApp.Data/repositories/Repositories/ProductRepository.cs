using Microsoft.EntityFrameworkCore;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.repositories.IRepostories;

namespace shoppingApp.Data.repositories.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> All(Guid businessId)
        {
            return await _dbSet
            .Where(x => x.BuisnessId == businessId)
            .ToListAsync();
        }

        public override async Task<Product> Get(Guid productId)
        {
            return await _dbSet
            .FirstAsync(x => x.Id == productId);
        }

        public override Task<bool> Delete(Product entity)
        {
            throw new NotImplementedException();
        }
        public decimal CaculateOrderCost(List<Product> products)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Get(Guid businessId, Guid ProductId)
        {
            return await _dbSet
            .Where(x => x.BuisnessId == businessId)
            .FirstAsync(x => x.Id == ProductId);
        }

        public async Task<IEnumerable<Product>> ProductsForBusiness(Guid userId, Guid businessId)
        {
            return await _dbSet
            .Where(x => x.BuisnessId == businessId)
            .ToListAsync();
        }

        public Task<Product> Get(Guid userId, Guid businessId, Guid ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> ProductsForUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
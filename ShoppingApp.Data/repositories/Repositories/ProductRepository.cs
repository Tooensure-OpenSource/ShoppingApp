using Microsoft.EntityFrameworkCore;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.repositories.IRepostories;

namespace shoppingApp.Data.repositories.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {}
        

        public override async Task<Product?> Get(Guid productId)
        {
            return await _dbSet
            .FirstOrDefaultAsync(x => x.Id == productId);
        }

        public override Task<bool> Delete(Product entity)
        {
            throw new NotImplementedException();
        }
        public decimal CaculateOrderCost(List<Product> products)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> Exist(Guid productId)
        {
            return await _dbSet
            .AnyAsync(x => x.Id == productId);
        }

        public async Task<bool> IsUserOfBusiness(Guid userId, Guid businessId)
        {
            var filterbusiness = await _dbSet
            .Include(x => x.Business)
            .Where(x => x.Business.Users.Any(x => x.Id == userId))
            .AnyAsync(x => x.BusinessId == businessId);

            return filterbusiness;
        }

        public Task<bool> BusinessExist(Guid businessId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsProductOfBusiness(Guid productId, Guid businessId)
        {
            var filterbusiness = await _dbSet
            .Include(x => x.Business)
            .Where(x => x.Business.Products.Any(x => x.Id == productId))
            .AnyAsync(x => x.BusinessId == businessId);

            return filterbusiness;
        }
    }
}
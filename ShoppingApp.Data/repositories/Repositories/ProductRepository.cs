using EcommerceApp.Domain.ResourceParameters.Search;
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

        public override void Delete(Product entity)
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

        public Task<bool> BusinessExist(Guid businessId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsProductOfBusiness(Guid productId, Guid businessId)
        {
            var filterbusiness = await _dbSet
            .Include(x => x.Businesses)
            .ThenInclude(x => x.Users)
            .Where(x => x.Businesses.Any(x => x.Id == businessId))
            .AnyAsync(x => x.Id == productId);

            return filterbusiness;
        }

        public async Task<bool> CanAddProduct(Guid userId, Guid businessId, Guid productId)
        {
            var filterbusiness = await _dbSet
            .Include(x => x.Businesses)
            .ThenInclude(x => x.Users)
            .Where(x => x.Businesses
            .Any(x => x.Id == businessId && 
            x.Users.Any(i => i.Id == userId)))
            .AnyAsync(x => x.Id == productId);

            return filterbusiness;
        }

        public async Task<IEnumerable<Product>> GetProducts(ProductSearch searchQuery)
        {
            // Store data in a collection ready for filtering
            var collection = await _dbSet
            .Include(x=>x.Businesses)
            .Where(x => x.Name.Contains(searchQuery.ProductName))
            .Where(x => x.Businesses.Any(x=>x.Id == searchQuery.BusinessId))
            .ToListAsync();
            return collection;
        }
    }
}
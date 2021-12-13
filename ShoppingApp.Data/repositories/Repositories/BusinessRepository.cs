using Microsoft.EntityFrameworkCore;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.repositories.IRepostories;

namespace shoppingApp.Data.repositories.Repositories
{
    public class BusinessRepository : GenericRepository<Business>, IBusinessRepository
    {
        public BusinessRepository(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Business>> All()
        {
            return await _dbSet
            .Include(x => x.Products)
            .Include(x => x.Users)
            .ToListAsync();
        }
        public override async Task<Business> Get(Guid businessId)
        {
            return await _dbSet
            .Include(x => x.Products)
            .Include(x => x.Users)
            .FirstAsync(x => x.Id == businessId);
        }
        public override Task<bool> Delete(Business entity)
        {
            throw new NotImplementedException();
        }
    }
}
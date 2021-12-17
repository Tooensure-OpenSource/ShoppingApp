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
        public override async Task<Business?> Get(Guid businessId)
        {
            return await _dbSet
            .Include(x => x.Orders)
            .Include(x => x.Products)
            .Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == businessId);
        }
        
        public async Task<bool> Exist(Guid businessId)
        {
            return await _dbSet
            .AnyAsync(x => x.Id == businessId);
        }


        ///<summary>
        /// Where else isn't better then checking if the user is
        /// in fact a business owner of this business
        /// NOTE: This may need some modifications
        ///</summary>
        public async Task<bool> IsOwnerOfBusiness(Guid userId, Guid businessId)
        {
            var filterbusiness = await _dbSet
            .Include(x => x.Users)
            .Where(x => x.Users.Any(x => x.Id == userId))
            .AnyAsync(x => x.Id == businessId);

            return filterbusiness;
        }
    }
}
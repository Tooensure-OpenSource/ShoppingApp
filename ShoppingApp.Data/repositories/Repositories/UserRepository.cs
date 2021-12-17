using Microsoft.EntityFrameworkCore;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.repositories.IRepostories;

namespace shoppingApp.Data.repositories.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<User>> All()
        {
            return await _dbSet
            .Include(x => x.Businesses)
            .Include(x => x.Orders)
            .ToListAsync();
        }
        public override async Task<User?> Get(Guid userId)
        {
            return await _dbSet
            .Include(x => x.Businesses)
            .FirstOrDefaultAsync(x => x.Id == userId);
        }


        public async Task<bool> Exist(Guid userId)
        {
            return await _dbSet
            .AnyAsync(x => x.Id == userId);
        }
    }
}
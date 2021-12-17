using EcommerceApp.Domain.ResourceParameters.Search;
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
        // Creating Search functionallity for user
        // now able to search and retrieve any user by username
        public async Task<IEnumerable<User>> Search(UserSearch userSearch)
        {
            return await _dbSet
            .Include(x => x.Businesses)
            .Include(x => x.Orders)
            .Where(x => x.Username == userSearch.Username)
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

        public async Task<bool> ExistByUsername(string username)
        {
            return await _dbSet
            .AnyAsync(x => x.Username == username);
        }
    }
}
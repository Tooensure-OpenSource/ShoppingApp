using Microsoft.EntityFrameworkCore;
using shoppingApp.Data.repositories.IRepostories;

namespace shoppingApp.Data.repositories.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        protected DbSet<T> _dbSet;
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        // Removing a items can be quite challanging
        // One must know when and doing so means at the best time possible
        // Most time delete can be done by upserting the the Object status to 0
        // else some action must triger 
        public virtual void  Delete(T entity) 
        { 
            _dbSet.Remove(entity);
        }
        public virtual void  Upsert(T entity) { }

        public virtual async Task<IEnumerable<T>> All()
        { 
            return await _dbSet
            .ToListAsync(); 
        }

        public virtual async Task<T?> Get(Guid Id)
        { 
            return await _dbSet
            .FirstOrDefaultAsync(); 
        }
    }
}
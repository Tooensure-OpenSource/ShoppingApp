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

        public override Task<bool> Delete(Business entity)
        {
            throw new NotImplementedException();
        }
    }
}
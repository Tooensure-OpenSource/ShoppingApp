using shoppingApp.Data.DbSet;

namespace shoppingApp.Data.repositories.IRepostories
{
    public interface IBusinessRepository : IGenericRepository<Business>
    {
        Task<bool> Exist(Guid businessId);

    }
}
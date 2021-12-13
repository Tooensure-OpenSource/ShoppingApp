using shoppingApp.Data.DbSet;

namespace shoppingApp.Data.repositories.IRepostories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> Exist(Guid userId);
    }
}
using EcommerceApp.Domain.ResourceParameters.Search;
using shoppingApp.Data.DbSet;

namespace shoppingApp.Data.repositories.IRepostories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> Search(UserSearch userSearch);
        Task<bool> Exist(Guid userId);
        Task<bool> ExistByUsername(string username);
        void Upsert(User user);
    }
}
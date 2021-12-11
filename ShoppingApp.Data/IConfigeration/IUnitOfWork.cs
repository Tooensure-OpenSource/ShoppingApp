using shoppingApp.Data.repositories.IRepostories;

namespace shoppingApp.Data.IConfigeration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IBusinessRepository Businesses { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        Task<bool> CompleteAsync();
    }
}
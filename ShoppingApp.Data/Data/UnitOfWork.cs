using shoppingApp.Data.IConfigeration;
using shoppingApp.Data.repositories.IRepostories;
using shoppingApp.Data.repositories.Repositories;


namespace shoppingApp.Data.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            UserRepository userContext = new(_context);
            BusinessRepository businessContext = new(_context);
            OrderRepository orderContext = new(_context);
            ProductRepository productContext = new(_context);

            Users = userContext;
            Businesses = businessContext;
            Orders = orderContext;
            Products = productContext;
        }
        public IUserRepository Users { get; set; }
        public IBusinessRepository Businesses { get; set; }
        public IOrderRepository Orders { get; set; }
        public IProductRepository Products { get; set; }

        public async Task<bool> CompleteAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
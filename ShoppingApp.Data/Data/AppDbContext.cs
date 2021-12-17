using Microsoft.EntityFrameworkCore;
using shoppingApp.Data.DbSet;

namespace shoppingApp.Data.Data
{
    public class AppDbContext : DbContext
    {
        // public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<User>? Users { get; set; }
        public DbSet<Business>? Businesses { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Order>? OrderItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-5FSN0VL\\TOOENSURE; Initial Catalog=ShoppingApp; Integrated Security=True");
        }
    }
}
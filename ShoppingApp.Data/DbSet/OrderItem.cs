using System.ComponentModel.DataAnnotations.Schema;
using shoppingApp.Data.DbSet;

namespace ShoppingApp.Data.DbSet
{
    public class OrderItem : EntityBase
    {
        public int Quantity { get; set; } = 1;
        // yes, List of products can be passed allowing the power
        // of each product has a quantity of 2
        public List<Product> Products { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
    }
}
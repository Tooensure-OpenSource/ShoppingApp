using System.ComponentModel.DataAnnotations.Schema;
using shoppingApp.Data.DbSet;

namespace ShoppingApp.Data.DbSet
{
    public class OrderItem : EntityBase
    {
       
        public int Quantity { get; set; } = 1;

        [ForeignKey("id")]
        public Guid ProductId { get; set; }
        public Product? Product { get; set; } = null;


        public OrderItem(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
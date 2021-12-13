using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShoppingApp.Data.DbSet;

namespace shoppingApp.Data.DbSet
{
    public class Order : EntityBase
    {
        public bool isComplete { get; set; } = false;

        [ForeignKey("id")]
        public Guid UserId { get; set; }
        public User? User { get; set; } = null;
        public List<OrderItem> OrderItems { get; set; } = new();

        [ForeignKey("id")]
        public Guid BusinessId { get; set; }
        public Business? Business { get; set; } = null;

        public decimal Total { get; set; }
    }
}
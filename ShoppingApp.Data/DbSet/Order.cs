using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoppingApp.Data.DbSet
{
    public class Order : EntityBase
    {
        [ForeignKey("id")]
        public Guid UserId { get; set; }
        public User? User { get; set; } = null;
        public List<Product> Products { get; set; } = new();

        [ForeignKey("id")]
        public Guid BuisnessId { get; set; }
        public Business? Business { get; set; } = null;

        public decimal Total { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShoppingApp.Data.DbSet;

namespace shoppingApp.Data.DbSet
{
    ///<summary>
    /// Products are a beutiful thing, its where we make transactions
    /// It's part of ecconomics. Trade. Here's why we do it the best.
    /// Product referances a business. Order Item referances a product.
    /// Order one2many Order Item
    /// Meaning long as we can access the order Item
    /// We should be able to access the product from the user.
    ///</summary>
    [Table("Products")]
    public class Product : EntityBase
    {
        [Required, MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
        public List<Business> Businesses { get; set; } = new();
        // [ForeignKey("id")]
        // public Guid BusinessId { get; set; }
        // public Business Business { get; set; } = new();        
    }
}
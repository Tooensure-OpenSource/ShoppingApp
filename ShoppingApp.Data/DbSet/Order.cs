using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShoppingApp.Data.DbSet;

namespace shoppingApp.Data.DbSet
{
    ///NOTE: Transaction Feature (sounds catchy)
    ///<summary>
    /// Here's where transaction is made and provides
    /// User and Business a gateway to product, indeed
    ///</summary>
    [Table("Orders")]
    public class Order : EntityBase
    {
        /// Purchase Feature needed also, this will allow users to make payment options
        /// note that, currently there's not any payment options rite now.
        /// Once all items is complete user will be allow
        // public List<object> Perchases { get; set; } = new();
        public bool isReady { get; set; } = false;
        public List<User> Users { get; set; } = new();
        public List<OrderItem> OrderItems { get; set; } = new();
        public List<Business> Businesses { get; set; } = new();
        // [ForeignKey("id")]
        // public Guid BusinessId { get; set; }
        // public Business? Business { get; set; } = null;

        public decimal Total { get; set; }
    }
}
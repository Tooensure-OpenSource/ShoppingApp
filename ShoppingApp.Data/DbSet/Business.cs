using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoppingApp.Data.DbSet
{
    ///<summary>
    /// Yes, Business creation starts the user off with a freash list
    /// of properties. It's a greate place to enhance and add sub-features.
    /// So now it wouldn't hurt to add products, orders, and users as sub-features.
    /// Why?, Well because, a business can have list of users (a list of owners, "feature comming soon")
    ///</summary>
    [Table("Businesses")]
    public class Business : EntityBase
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string Username { get; set; } = string.Empty;
        
        /// Place Sub-Features go here..
        public List<Product> Products { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
        public List<User> Users { get; set; } = new();
        
    }
}
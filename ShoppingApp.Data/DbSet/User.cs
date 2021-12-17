using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShoppingApp.Data.DbSet;

namespace shoppingApp.Data.DbSet
{

    ///<summary>
    /// User represents the base logic of opperation.
    /// User object intergrates well with authentication and authorization.
    /// User also can create businesses. Thought i'll fit well when defining
    /// relationship between the user and the business,
    /// as well as orders. 
    ///</summary>
    [Table("Users")]
    public class User : EntityBase
    {
        [Required, MaxLength(50)]
        public string? FirstName { get; set; }
        [Required, MaxLength(50)]
        public string? LastName { get; set; }
        [Required, MaxLength(100)]
        public string? Username { get; set; } = null;
        [Required,EmailAddress, MaxLength(50)]
        public string EmailAddress { get; set; } = String.Empty;
        /// Recipt Feature needed, because how else can user
        /// access there product and/or orders when business deletes,
        /// add and save this data into new Recipt
        /// For now this issue is patched with a enum specifing if
        /// the status of object object is active, deactive, etc.
        /// TIP: if business has never made a order then full delete
        /// is very much able and will defualt to conflict
        public List<Order> Orders { get; } = new();
        public List<Business> Businesses { get; } = new();

    }
}
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
        ///<summary>
        /// The first name of the user
        ///</summary>
        [Required, MaxLength(50)]
        public string? FirstName { get; set; }
        ///<summary>
        /// The last name of the user
        ///</summary>
        [Required, MaxLength(50)]
        public string? LastName { get; set; }
        ///<summary>
        /// The username of the user
        ///</summary>
        [Required, MaxLength(100)]
        public string? Username { get; set; } = null;
        ///<summary>
        /// The email of the user
        ///</summary>
        [Required,EmailAddress, MaxLength(50)]
        public string EmailAddress { get; set; } = String.Empty;
        ///<summary>
        /// The orders the user made
        ///</summary>
        public List<Order> Orders { get; } = new();
        ///<summary>
        /// The businesses the user created
        ///</summary>
        public List<Business> Businesses { get; } = new();

    }
}
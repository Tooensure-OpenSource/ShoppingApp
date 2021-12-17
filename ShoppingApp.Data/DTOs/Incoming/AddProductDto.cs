using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Data.DTOs.Incoming
{
    ///<summary>
    /// The first name of the user
    ///</summary>
    public class AddProductDto
    {
        ///<summary>
        /// The first name of the user
        ///</summary>
        [Required]
        public Guid BusinessId { get; set; }
        ///<summary>
        /// The first name of the user
        ///</summary>
        [Required]
        public Guid UserId { get; set; }
        ///<summary>
        /// The first name of the user
        ///</summary>
        [Required]
        public string Name { get; set; } = string.Empty;
        ///<summary>
        /// The first name of the user
        ///</summary>
        public decimal Cost { get; set; }
    }
}
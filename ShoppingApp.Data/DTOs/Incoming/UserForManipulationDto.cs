using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Data.DTOs.Incoming
{
    ///<summary>
    /// An add user dto. with Firstname, Lastname, Username, and email fields
    ///</summary>
    public abstract class UserForManipulationDto
    {
        ///<summary>
        /// The first name of the user
        ///</summary>
        [Required]
        public virtual string FirstName { get; set; } = string.Empty;
        ///<summary>
        /// The last name of the user
        ///</summary>
        [Required]
        public virtual string LastName { get; set; } = string.Empty;
        ///<summary>
        /// The username of the user
        ///</summary>
        [Required]
        public virtual string Username { get; set; } = string.Empty;
        ///<summary>
        /// The email of the user
        ///</summary>
        public virtual string EmailAddress { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;
using ShoppingApp.Data.DTOs.Incoming;

namespace ShoppingApp.Data.DTOs.UserDto
{
    ///<summary>
    /// An add user dto. with Firstname, Lastname, Username, and email fields
    ///</summary>
    public class AddUserDto : UserForManipulationDto
    {
        ///<summary>
        /// The email of the user
        ///</summary>
        [Required,EmailAddress]
        public override string EmailAddress { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;
using ShoppingApp.Data.DTOs.Incoming;

namespace ShoppingApp.Data.DTOs.UserDto
{
    public class AddUserDto : UserForManipulationDto
    {
        [Required,EmailAddress]
        public override string EmailAddress { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Data.DTOs.Incoming.UpdateDto
{
    public class UserUpdateDto : UserForManipulationDto
    {
        public override string FirstName { get; set; } = string.Empty;
        public override string LastName { get; set; } = string.Empty;

    }
}
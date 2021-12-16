using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Data.DTOs.Incoming
{
    public abstract class UserForManipulationDto
    {
        [Required]
        public virtual string FirstName { get; set; } = string.Empty;
        [Required]
        public virtual string LastName { get; set; } = string.Empty;
        public virtual string EmailAddress { get; set; } = string.Empty;
    }
}
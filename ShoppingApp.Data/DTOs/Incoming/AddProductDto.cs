using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Data.DTOs.Incoming
{
    public class AddProductDto
    {
        [Required]
        public Guid BusinessId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
    }
}
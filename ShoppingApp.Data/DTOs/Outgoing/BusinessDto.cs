using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Data.DTOs.Outgoing
{
    public class BusinessDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Products { get; set; } = new();
        public int Orders { get; set; } = new();
        public int Users { get; set; } = new();
        public DateTime DateCreated { get; set; }
    }
}
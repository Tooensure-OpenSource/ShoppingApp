using System.ComponentModel.DataAnnotations;

namespace shoppingApp.Data.DbSet
{
    public class Business : EntityBase
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
    }
}
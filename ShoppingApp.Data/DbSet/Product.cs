using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoppingApp.Data.DbSet
{
    public class Product : EntityBase
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        
        [ForeignKey("id")]
        public Guid BuisnessId { get; set; }
        public Business? Business { get; set; } = null;
        
        public List<User> Users { get; set; } = new();
        

    }
}
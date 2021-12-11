using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace shoppingApp.Data.DbSet
{
    public class User : EntityBase
    {
        public string? FristName { get; set; }
        public string? LastName { get; set; }

        [Required,EmailAddress]
        public string EmailAddress { get; set; } = String.Empty;
        public List<Order> Orders { get; set; } = new();
        public List<Product> Products { get; set; } = new();

    }
}
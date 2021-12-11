namespace ShoppingApp.Data.DTOs.Outgoing
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public Guid BusinessId { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
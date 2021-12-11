namespace ShoppingApp.Data.DTOs.Outgoing
{
    public class BusinessDto
    {
        public Guid Id { get; set; }
        public List<ProductDto> Products { get; set; } = new();
        public List<OrderDto> Orders { get; set; } = new();
        public DateTime DateCreated { get; set; }
    }
}
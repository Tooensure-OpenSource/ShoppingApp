namespace ShoppingApp.Data.DTOs.Incoming
{
    public class AddProductDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
    }
}
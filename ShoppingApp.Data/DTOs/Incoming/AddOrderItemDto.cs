namespace ShoppingApp.Data.DTOs.Incoming
{
    public class AddOrderItemDto
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
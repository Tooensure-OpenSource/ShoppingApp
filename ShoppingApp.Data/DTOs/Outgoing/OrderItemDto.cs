namespace ShoppingApp.Data.DTOs.Outgoing
{
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public Guid OrderItemId { get; set; }
        public int Quantity { get; set; }
    }
}
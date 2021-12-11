namespace ShoppingApp.Data.DTOs.Incoming
{
    public class AddOrderDto
    {
        public Guid UserId { get; set; }
        public Guid BusinessId { get; set; }
    }
}
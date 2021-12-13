namespace ShoppingApp.Data.DTOs.Outgoing
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BusinessId { get; set; }
        public int OrderItems { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
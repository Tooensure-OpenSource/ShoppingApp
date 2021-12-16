namespace EcommerceApp.Domain.ResourceParameters.Search
{
    public class ProductSearch
    {
        public Guid BusinessId { get; set; }
        public string ProductName { get; set; } = string.Empty;
    }
}
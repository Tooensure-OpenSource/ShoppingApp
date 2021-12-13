namespace shoppingApp.Data.DbSet
{
    public class EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? DateCreated { get; set; } = new();
    }
}
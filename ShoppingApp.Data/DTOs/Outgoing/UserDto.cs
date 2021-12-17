namespace ShoppingApp.Data.DTOs.UserDto
{
    public class UserDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;
        public int Orders { get; set; }
        public int Businesses { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
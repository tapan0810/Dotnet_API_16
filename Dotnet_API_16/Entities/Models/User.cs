namespace Dotnet_API_16.Entities.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string UserName { get; set; } = string.Empty;
        public required string PasswordHash { get; set; } = string.Empty;
    }
}

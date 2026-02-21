namespace Dotnet_API_16.Entities.UserDtos
{
    public class UserLoginDto
    {
        public required string UserName { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
    }
}

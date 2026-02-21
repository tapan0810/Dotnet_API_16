namespace Dotnet_API_16.Entities.UserDtos
{
    public class UserRegisterDto
    {
        public required string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

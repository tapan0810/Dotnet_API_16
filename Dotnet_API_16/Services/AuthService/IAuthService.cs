using Dotnet_API_16.Entities.Models;
using Dotnet_API_16.Entities.UserDtos;

namespace Dotnet_API_16.Services.AuthService
{
    public interface IAuthService
    {
        public Task<User> Register(UserRegisterDto request);
        public Task<string> Login(UserLoginDto request);
    }
}

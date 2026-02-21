using Dotnet_API_16.Entities.Models;

namespace Dotnet_API_16.Helper.JwtHelper
{
    public interface IJwtHelper
    {
        public string GenerateToken(User user);
    }
}

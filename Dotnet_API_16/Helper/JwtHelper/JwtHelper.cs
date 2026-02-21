using Dotnet_API_16.Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dotnet_API_16.Helper.JwtHelper
{
    public class JwtHelper(IConfiguration configuration) : IJwtHelper
    {
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Issue")!));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer:configuration.GetValue<string>("AppSettings:issuer"),
                audience:configuration.GetValue<string>("AppSettinga:audience"),
                claims:claims,
                expires:DateTime.UtcNow.AddDays(1),
                signingCredentials:creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}

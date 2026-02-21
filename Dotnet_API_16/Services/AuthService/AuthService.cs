using Dotnet_API_16.Data;
using Dotnet_API_16.Entities.Models;
using Dotnet_API_16.Entities.UserDtos;
using Dotnet_API_16.Helper.JwtHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_16.Services.AuthService
{
    public class AuthService(CompanyDbContext _context , IJwtHelper jwtHelper) : IAuthService
    {
        public async Task<string> Login(UserLoginDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x =>x.UserName == request.UserName);

            if (user is null)
                return null;

            if(user.UserName != request.UserName)
                return null;

            if(new PasswordHasher<User>().VerifyHashedPassword(user,user.PasswordHash,request.Password) == PasswordVerificationResult.Failed)
            {
                return null;

            }

            string token = jwtHelper.GenerateToken(user);
            return token;
        }

        public async Task<User> Register(UserRegisterDto request)
        {
            if(await _context.Users.AnyAsync(x => x.UserName == request.UserName))
            {
                return null;
            }

            var user = new User
            {
                UserName = request.UserName
            };

            var HashPassword = new PasswordHasher<User>().HashPassword(user,request.Password);
            user.UserName = request.UserName;
            user.PasswordHash = HashPassword;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}

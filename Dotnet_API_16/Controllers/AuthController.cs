using Dotnet_API_16.Entities.Models;
using Dotnet_API_16.Entities.UserDtos;
using Dotnet_API_16.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_API_16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserRegisterDto request)
        {
            var user = await authService.Register(request);
            if (user is null)
            {
                return BadRequest("User could not be registered");
            }
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLoginDto request)
        {
            var token = await authService.Login(request);
            if (token is null)
            {
                return BadRequest("Invalid username or password");
            }
            return Ok(token);
        }
    }
}

using GymManagement.Application.Features.Auths.Commands.Login;
using GymManagement.Application.Features.Auths.Commands.Register;
using GymManagement.Infrastructure.Authentication.Dtos.User;
using GymManagement.Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _meditor;

        protected string? GetIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For")) return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }


        public AuthController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                IpAddress = GetIpAddress(),
                UserForRegisterDto = userForRegisterDto,
            };

            RegisteredDto result = await _meditor.Send(registerCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new()
            {
                IpAddress = GetIpAddress(),
                UserForLoginDto = userForLoginDto,
            };

            LoggedDto result = await _meditor.Send(loginCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new()
            {
                HttpOnly = true,
                Expires = DateTimeOffset.Now.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}

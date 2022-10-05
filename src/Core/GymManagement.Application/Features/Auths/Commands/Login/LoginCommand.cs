using GymManagement.Application.Features.Rules;
using GymManagement.Application.Interfaces.AuthService;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Infrastructure.Authentication.Dtos.User;
using GymManagement.Infrastructure.Authentication.JWT;
using GymManagement.Infrastructure.Entities;
using MediatR;

namespace GymManagement.Application.Features.Auths.Commands.Login
{
    public class LoginCommand: IRequest<LoggedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;

            public LoginCommandHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
            {
                _authBusinessRules = authBusinessRules;
                _userRepository = userRepository;
                _authService = authService;
            }

            public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

                await _authBusinessRules.MailMustExistWhenLoggingIn(request.UserForLoginDto.Email);
                await _authBusinessRules.VerifyUserPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                LoggedDto loggedDto = new()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken,
                };

                return loggedDto;
            }
        }
    }
}

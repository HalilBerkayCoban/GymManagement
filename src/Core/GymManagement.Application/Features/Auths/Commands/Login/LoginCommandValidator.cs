using FluentValidation;

namespace GymManagement.Application.Features.Auths.Commands.Login
{
    public class LoginCommandValidator: AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(u => u.UserForLoginDto.Email).NotEmpty().NotNull().EmailAddress();

            RuleFor(u => u.UserForLoginDto.Password).NotEmpty().NotNull();
        }
    }
}

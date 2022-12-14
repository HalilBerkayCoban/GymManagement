using FluentValidation;

namespace GymManagement.Application.Features.Trainers.Commands.UpdateTrainer
{
    public class UpdateTrainerCommandValidator: AbstractValidator<UpdateTrainerCommand>
    {
        public UpdateTrainerCommandValidator()
        {
            RuleFor(rf => rf.Email).NotEmpty().NotNull().WithMessage("Email cannot be empty");
            RuleFor(rf => rf.FirstName).NotEmpty().NotNull().WithMessage("First Name cannot be empty");
            RuleFor(rf => rf.LastName).NotEmpty().NotNull().WithMessage("Last Name cannot be empty.");
            RuleFor(rf => rf.DateOfBirth).NotEmpty().NotNull().WithMessage("Birth Date cannot be empty");
            RuleFor(m => m.PhoneNumber).NotNull().NotEmpty().WithMessage("Phone number cannot be empty.");
        }
    }
}

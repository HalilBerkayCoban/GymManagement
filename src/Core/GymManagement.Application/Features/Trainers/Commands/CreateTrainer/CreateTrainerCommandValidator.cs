using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Features.Trainers.Commands.CreateTrainer
{
    public class CreateTrainerCommandValidator: AbstractValidator<CreateTrainerCommand>
    {
        public CreateTrainerCommandValidator()
        {
            RuleFor(rf => rf.Email).NotEmpty().NotNull().WithMessage("Email cannot be empty");
            RuleFor(rf => rf.FirstName).NotEmpty().NotNull().WithMessage("First Name cannot be empty");
            RuleFor(rf => rf.LastName).NotEmpty().NotNull().WithMessage("Last Name cannot be empty.");
            RuleFor(rf => rf.DateOfBirth).NotEmpty().NotNull().WithMessage("Birth Date cannot be empty");
            RuleFor(m => m.PhoneNumber).NotNull().NotEmpty().WithMessage("Phone number cannot be empty.");
        }
    }
}

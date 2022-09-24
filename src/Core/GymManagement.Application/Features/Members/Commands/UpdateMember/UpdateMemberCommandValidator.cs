using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Features.Members.Commands.UpdateMember
{
    public class UpdateMemberCommandValidator: AbstractValidator<UpdateMemberCommand>
    {
        public UpdateMemberCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
            RuleFor(m => m.UpdatedAt).NotEmpty();
            RuleFor(m => m.TrainerId).NotEmpty().WithMessage("Trainer cannot be empty.");
            RuleFor(m => m.FirstName).NotEmpty().WithMessage("First name cannot be empty.");
            RuleFor(m => m.LastName).NotEmpty().WithMessage("Last name cannot be empty.");
            RuleFor(m => m.DateOfBirth).NotEmpty().WithMessage("Date of birth cannot be empty.");
            RuleFor(m => m.Weight).NotEmpty().WithMessage("Weight cannot be empty.");
            RuleFor(m => m.Height).NotEmpty().WithMessage("Height cannot be empty.");
            RuleFor(m => m.PhoneNumber).NotEmpty().WithMessage("Phone number cannot be empty.");
            RuleFor(m => m.Email).NotEmpty().WithMessage("Email cannot be empty.");
            RuleFor(m => m.Status).NotEmpty();
        }
    }
}

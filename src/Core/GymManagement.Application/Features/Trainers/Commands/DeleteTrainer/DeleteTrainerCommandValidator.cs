using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Features.Trainers.Commands.DeleteTrainer
{
    public class DeleteTrainerCommandValidator: AbstractValidator<DeleteTrainerCommand>
    {
        public DeleteTrainerCommandValidator()
        {
            RuleFor(rf => rf.Id).NotEmpty().NotNull();
        }
    }
}

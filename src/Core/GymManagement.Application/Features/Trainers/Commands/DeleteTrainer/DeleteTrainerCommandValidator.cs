using FluentValidation;

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

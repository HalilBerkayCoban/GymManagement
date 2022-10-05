using FluentValidation;

namespace GymManagement.Application.Features.Members.Commands.DeleteMember
{
    public class DeleteMemberCommandValidator
    {
        public class DeleteByMemberNumberCommandValidator : AbstractValidator<DeleteMemberCommand>
        {
            public DeleteByMemberNumberCommandValidator()
            {
                RuleFor(m => m.Id).NotEmpty();
            }
        }
    }
}

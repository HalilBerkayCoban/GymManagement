using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Features.Members.Commands.DeleteMember
{
    public class DeleteMemberCommandValidator
    {
        public class DeleteByMemberNumberCommandValidator : AbstractValidator<DeleteMemberCommand>
        {
            public DeleteByMemberNumberCommandValidator()
            {
                RuleFor(b => b.MemberNumber).NotEmpty();
            }
        }
    }
}

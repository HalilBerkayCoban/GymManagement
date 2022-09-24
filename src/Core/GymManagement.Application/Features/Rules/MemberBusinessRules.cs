using GymManagement.Application.Exceptions;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Features.Rules
{
    public class MemberBusinessRules: CommonBusinessRules
    {
        private readonly IMemberRepository _memberRepository;

        public MemberBusinessRules(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task MemberShouldExistWhenRequested(Member member)
        {
            if (member == null) throw new BusinessException("Requested member does not exist");
        }
    }
}

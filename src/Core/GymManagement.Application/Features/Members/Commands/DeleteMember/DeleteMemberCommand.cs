using AutoMapper;
using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Features.Rules;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Features.Members.Commands.DeleteMember
{
    public class DeleteMemberCommand: IRequest<DeletedMemberDto>
    {
        public int Id { get; set; }
        public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, DeletedMemberDto>
        {
            private readonly IMemberRepository _memberRepository;
            private readonly IMapper _mapper;
            private readonly MemberBusinessRules _memberBusinessRules;

            public DeleteMemberCommandHandler(IMemberRepository memberRepository, IMapper mapper, MemberBusinessRules memberBusinessRules)
            {
                _memberRepository = memberRepository;
                _mapper = mapper;
                _memberBusinessRules = memberBusinessRules;
            }

            public async Task<DeletedMemberDto> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
            {
                Member member = await _memberRepository.GetAsync(i => i.Id == request.Id);
                await _memberBusinessRules.MemberShouldExistWhenRequested(member);
                Member deletedMember =  await _memberRepository.DeleteAsync(member);
                DeletedMemberDto deletedMemberDto = _mapper.Map<DeletedMemberDto>(deletedMember);
                return deletedMemberDto;
            }
        }
    }
}

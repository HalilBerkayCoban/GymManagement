using AutoMapper;
using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Features.Rules;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using MediatR;

namespace GymManagement.Application.Features.Members.Commands.CreateMember
{
    public class CreateMemberCommand: IRequest<CreatedMemberDto>
    {
        public int TrainerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
        public decimal Height { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, CreatedMemberDto>
        {
            private readonly IMemberRepository _memberRepository;
            private readonly IMapper _mapper;
            private readonly MemberBusinessRules _memberBusinessRules;

            public CreateMemberCommandHandler(IMemberRepository memberRepository, IMapper mapper, MemberBusinessRules memberBusinessRules)
            {
                _memberRepository = memberRepository;
                _mapper = mapper;
                _memberBusinessRules = memberBusinessRules;
            }

            public async Task<CreatedMemberDto> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
            {
                Member mappedMember = _mapper.Map<Member>(request);
                await _memberBusinessRules.GivenEmailShoulBeValid(mappedMember);
                Member createdMember = await _memberRepository.AddAsync(mappedMember);
                CreatedMemberDto createdMemberDto = _mapper.Map<CreatedMemberDto>(createdMember);
                return createdMemberDto;
            }
        }
    }
}

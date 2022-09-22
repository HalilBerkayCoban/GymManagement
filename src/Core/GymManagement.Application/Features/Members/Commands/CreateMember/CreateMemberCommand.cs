using AutoMapper;
using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Features.Members.Commands.CreateMember
{
    public class CreateMemberCommand: IRequest<CreatedMemberDto>
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
        public decimal Height { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

        public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, CreatedMemberDto>
        {
            private readonly IMemberRepository _memberRepository;
            private readonly IMapper _mapper;

            public CreateMemberCommandHandler(IMemberRepository memberRepository, IMapper mapper)
            {
                _memberRepository = memberRepository;
                _mapper = mapper;
            }

            public async Task<CreatedMemberDto> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
            {
                Member mappedMember = _mapper.Map<Member>(request);
                Member createdMember = await _memberRepository.AddAsync(mappedMember);
                CreatedMemberDto createdMemberDto = _mapper.Map<CreatedMemberDto>(createdMember);
                return createdMemberDto;
            }
        }
    }
}

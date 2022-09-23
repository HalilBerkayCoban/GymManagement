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

namespace GymManagement.Application.Features.Members.Commands.UpdateMember
{
    public class UpdateMemberCommand: IRequest<UpdatedMemberDto>
    {
        public int MemberNumber { get; set; }
        public int TrainerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
        public decimal Height { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, UpdatedMemberDto>
        {
            private readonly IMemberRepository _memberRepository;
            private readonly IMapper _mapper;

            public UpdateMemberCommandHandler(IMemberRepository memberRepository, IMapper mapper)
            {
                _memberRepository = memberRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedMemberDto> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
            {
                Member? member = await _memberRepository.GetAsync(i => i.MemberNumber == request.MemberNumber);

                member.TrainerNumber = request.TrainerNumber;
                member.FirstName = request.FirstName;
                member.LastName = request.LastName;
                member.Email = request.Email;
                member.DateOfBirth = request.DateOfBirth;
                member.Weight = request.Weight;
                member.Height = request.Height;
                member.PhoneNumber = request.PhoneNumber;
                member.Status = request.Status;
                member.UpdatedAt = DateTimeOffset.UtcNow;

                Member updatedMember = await _memberRepository.UpdateAsync(member);
                UpdatedMemberDto updatedMemberDto = _mapper.Map<UpdatedMemberDto>(updatedMember);
                return updatedMemberDto;
            }
        }
    }
}

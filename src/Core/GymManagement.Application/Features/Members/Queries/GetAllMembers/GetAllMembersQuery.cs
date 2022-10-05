using AutoMapper;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Interfaces.Paging;
using GymManagement.Application.Requests;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Application.Features.Members.Queries.GetAllMembers
{
    public class GetAllMembersQuery: IRequest<MemberListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetAllMembersQueryHandler : IRequestHandler<GetAllMembersQuery, MemberListModel>
        {
            private readonly IMemberRepository _memberRepository;
            private readonly IMapper _mapper;

            public GetAllMembersQueryHandler(IMemberRepository memberRepository, IMapper mapper)
            {
                _memberRepository = memberRepository;
                _mapper = mapper;
            } 

            public async Task<MemberListModel> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Member> members = await _memberRepository.GetListAsync(include: m => m.Include(i => i.Trainer), index: request.PageRequest.Page, size: request.PageRequest.PageSize, enableTracking: false);

                MemberListModel memberListModel = _mapper.Map<MemberListModel>(members);

                return memberListModel;
            }
        }
    }
}

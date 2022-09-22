using AutoMapper;
using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Features.Members.Models;
using GymManagement.Application.Interfaces.Paging;
using GymManagement.Application.Requests;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                IPaginate<Member> members = await _memberRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                MemberListModel memberListModel = _mapper.Map<MemberListModel>(members);

                return memberListModel;
            }
        }
    }
}

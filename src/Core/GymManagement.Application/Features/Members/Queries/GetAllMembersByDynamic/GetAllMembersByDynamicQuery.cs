using AutoMapper;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Interfaces.Dynamic;
using GymManagement.Application.Interfaces.Paging;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Application.Requests;
using GymManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Application.Features.Members.Queries.GetAllMembersByDynamic
{
    public class GetAllMembersByDynamicQuery: IRequest<MemberListModel>
    {
        public Dynamic Dynamic{ get; set; }
        public PageRequest PageRequest { get; set; }
        public class GetAllMembersByDynamicQueryHandler : IRequestHandler<GetAllMembersByDynamicQuery, MemberListModel>
        {
            private readonly IMemberRepository _memberRepository;
            private readonly IMapper _mapper;

            public GetAllMembersByDynamicQueryHandler(IMemberRepository memberRepository, IMapper mapper)
            {
                _memberRepository = memberRepository;
                _mapper = mapper;
            }

            public async Task<MemberListModel> Handle(GetAllMembersByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Member> members = await _memberRepository.GetListByDynamicAsync(request.Dynamic, include: m => m.Include(i => i.Trainer), 
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize, enableTracking: false);

                MemberListModel memberListModel = _mapper.Map<MemberListModel>(members);

                return memberListModel;
            }
        }
    }
}

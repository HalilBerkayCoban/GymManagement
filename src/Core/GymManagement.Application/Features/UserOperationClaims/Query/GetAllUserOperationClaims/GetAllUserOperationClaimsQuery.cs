using AutoMapper;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Interfaces.Paging;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Application.Features.UserOperationClaims.Query.GetAllUserOperationClaims
{
    public class GetAllUserOperationClaimsQuery : IRequest<UserOperationClaimListModel>
    {
        public int UserId { get; set; }
        public string[] Roles => new[] { "Admin" };


        public class GetUserOperationClaimByUserQueryHandler : IRequestHandler<GetAllUserOperationClaimsQuery, UserOperationClaimListModel>
        {
            IUserOperationClaimRepository _userOperationClaimRepository;
            IMapper _mapper;

            public GetUserOperationClaimByUserQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UserOperationClaimListModel> Handle(GetAllUserOperationClaimsQuery request,
                CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(include: m => m.Include(c => c.User)
                        .Include(c => c.OperationClaim)
                );
                UserOperationClaimListModel userOperationClamListModel = _mapper.Map<UserOperationClaimListModel>(userOperationClaims);
                return userOperationClamListModel;
            }
        }
    }
}

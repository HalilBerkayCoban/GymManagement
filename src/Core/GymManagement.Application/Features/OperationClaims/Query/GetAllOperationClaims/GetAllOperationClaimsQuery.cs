using AutoMapper;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Interfaces.Paging;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Application.Requests;
using GymManagement.Infrastructure.Entities;
using MediatR;

namespace GymManagement.Application.Features.OperationClaims.Query.GetAllOperationClaims
{
    public class GetAllOperationClaimsQuery: IRequest<OperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllOperationClaimsQueryHandler : IRequestHandler<GetAllOperationClaimsQuery, OperationClaimListModel>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public GetAllOperationClaimsQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<OperationClaimListModel> Handle(GetAllOperationClaimsQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                OperationClaimListModel operationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaims);
                return operationClaimListModel;
            }
        }
    }
}

using AutoMapper;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Infrastructure.Authentication.Dtos.UserOperationClaim;
using GymManagement.Infrastructure.Entities;
using MediatR;

namespace GymManagement.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>
    {
        public int UserId { get; set; }
        public int OperationId { get; set; }
        public string[] Roles => new[] { "Admin" };

        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand,
        CreatedUserOperationClaimDto>
        {
            private IUserOperationClaimRepository _userOperationClaimRepository;
            private IMapper _mapper;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request,
                CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim createdUserOperationClaim = await _userOperationClaimRepository.AddAsync(userOperationClaim);
                CreatedUserOperationClaimDto createdUserOperationDto = _mapper.Map<CreatedUserOperationClaimDto>(createdUserOperationClaim);
                return createdUserOperationDto;
            }
        }

    }
}

using AutoMapper;
using GymManagement.Application.Dtos.UserOperationClaim;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using MediatR;

namespace GymManagement.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaims
{
    public class DeleteUserOperationClaimCommand: IRequest<DeletedUserOperationClaimDto>
    {
        public int Id { get; set; }
        public string[] Roles => new[] { "Admin" };


        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand,
            DeletedUserOperationClaimDto>
        {
            private IUserOperationClaimRepository _userOperationClaimRepository;
            private IMapper _mapper;


            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request,
                CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(userOperationClaim);
                DeletedUserOperationClaimDto deletedUserOperationDto = _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);
                return deletedUserOperationDto;
            }
        }
    }
}

using AutoMapper;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using GymManagement.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaims;
using GymManagement.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaims;
using GymManagement.Application.Interfaces.Paging;
using GymManagement.Infrastructure.Authentication.Dtos.UserOperationClaim;
using GymManagement.Infrastructure.Entities;

namespace GymManagement.Application.Mappings
{
    public class UserOperationClaimsProfiles: Profile
    {
        public UserOperationClaimsProfiles()
        {
            //CreateOperationClaim
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();

            //ReadOperationClaims
            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
            CreateMap<UserOperationClaim, OperationClaimListModel>().ReverseMap();

            //UpdateOperationClaim
            CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();

            //DeleteOperationClaim
            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
        }
    }
}

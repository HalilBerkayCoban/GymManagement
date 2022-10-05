using AutoMapper;
using GymManagement.Application.Features.Models;
using GymManagement.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using GymManagement.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using GymManagement.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using GymManagement.Application.Interfaces.Paging;
using GymManagement.Infrastructure.Authentication.Dtos.OperationClaim;
using GymManagement.Infrastructure.Entities;

namespace GymManagement.Application.Mappings
{
    public class OperationClaimProfiles: Profile
    {
        public OperationClaimProfiles()
        {
            //CreateOperationClaim
            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();

            //ReadOperationClaims
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListModel>().ReverseMap();

            //UpdateOperationClaim
            CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();

            //DeleteOperationClaim
            CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
        }
    }
}

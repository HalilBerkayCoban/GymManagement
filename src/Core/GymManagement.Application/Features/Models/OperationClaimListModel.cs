using GymManagement.Application.Interfaces.Paging;
using GymManagement.Infrastructure.Authentication.Dtos.OperationClaim;

namespace GymManagement.Application.Features.Models
{
    public class OperationClaimListModel: BasePageableModel
    {
        public IList<OperationClaimListDto> Items { get; set; }
    }
}

using GymManagement.Application.Dtos.OperationClaim;
using GymManagement.Application.Interfaces.Paging;

namespace GymManagement.Application.Features.Models
{
    public class OperationClaimListModel: BasePageableModel
    {
        public IList<OperationClaimListDto> Items { get; set; }
    }
}

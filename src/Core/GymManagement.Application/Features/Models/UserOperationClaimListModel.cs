using GymManagement.Application.Interfaces.Paging;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Features.Models
{
    public class UserOperationClaimListModel : BasePageableModel
    {
        public IList<UserOperationClaim> Items { get; set; }
    }
}

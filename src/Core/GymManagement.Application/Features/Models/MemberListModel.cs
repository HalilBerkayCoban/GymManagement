using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Interfaces.Paging;

namespace GymManagement.Application.Features.Models
{
    public class MemberListModel: BasePageableModel
    {
        public IList<MemberListDto> Items { get; set; }
    }
}

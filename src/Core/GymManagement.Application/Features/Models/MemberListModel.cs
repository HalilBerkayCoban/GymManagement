using GymManagement.Application.Dtos.Member;
using GymManagement.Application.Interfaces.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Features.Models
{
    public class MemberListModel: BasePageableModel
    {
        public IList<MemberListDto> Items { get; set; }
    }
}

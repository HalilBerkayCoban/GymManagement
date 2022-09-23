using GymManagement.Application.Dtos.Trainer;
using GymManagement.Application.Interfaces.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Features.Models
{
    public class TrainerListModel : BasePageableModel
    {
        public IList<TrainerListDto> Items { get; set; }
    }
}

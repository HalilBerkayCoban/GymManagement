using GymManagement.Application.Dtos.Trainer;
using GymManagement.Application.Interfaces.Paging;

namespace GymManagement.Application.Features.Models
{
    public class TrainerListModel : BasePageableModel
    {
        public IList<TrainerListDto> Items { get; set; }
    }
}

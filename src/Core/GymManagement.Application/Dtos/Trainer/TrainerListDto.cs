using GymManagement.Application.Dtos.Member;

namespace GymManagement.Application.Dtos.Trainer
{
    public class TrainerListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Branch { get; set; }
        public ICollection<MemberListDto> Members { get; set; }
    }
}

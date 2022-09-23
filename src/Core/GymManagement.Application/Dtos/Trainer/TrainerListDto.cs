using GymManagement.Application.Dtos.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Dtos.Trainer
{
    public class TrainerListDto
    {
        public int TrainerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Branch { get; set; }
        public ICollection<MemberListDto> Members { get; set; }
    }
}

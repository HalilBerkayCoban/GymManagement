using GymManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Domain.Entities
{
    public class Trainer: BaseEntity
    {
        public int TrainerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Branch { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public ICollection<Member> Members { get; set; }

        public Trainer()
        {

        }

        public Trainer(int trainerNumber, string firstName, string lastName, string branch, string phoneNumber, string email, bool status, DateTimeOffset createadAt, DateTimeOffset updatedAt) : this()
        {
            TrainerNumber = trainerNumber;
            FirstName = firstName;
            LastName = lastName;
            Branch = branch;
            PhoneNumber = phoneNumber;
            Email = email;
            Status = status;
            CreatedAt = createadAt;
            UpdatedAt = updatedAt;
        }
    }
}

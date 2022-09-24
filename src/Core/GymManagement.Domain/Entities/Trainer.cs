using GymManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Domain.Entities
{
    public class Trainer: BasePersonEntity
    {
        public string Branch { get; set; }
        public ICollection<Member> Members { get; set; }

        public Trainer()
        {

        }

        public Trainer(int id, string firstName, string lastName, string branch, string phoneNumber, string email, bool status, DateTimeOffset createadAt, DateTimeOffset updatedAt) : this()
        {
            Id = id;
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

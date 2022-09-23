using GymManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Domain.Entities
{
    public class Member : BaseEntity
    {
        public int MemberNumber { get; set; }
        public int TrainerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
        public decimal Height { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public Trainer Trainer { get; set; }

        public Member()
        {

        }

        public Member(DateTimeOffset createdAt, DateTimeOffset updatedAt, int memberNumber, int trainerNumber, string firstName, string lastName, DateTime dateOfBirth, double weight, decimal height, string phoneNumber, string email, bool status) : this()
        {
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            MemberNumber = memberNumber;
            TrainerNumber = trainerNumber;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Weight = weight;
            Height = height;
            PhoneNumber = phoneNumber;
            Email = email;
            Status = status;
        }
    }
}

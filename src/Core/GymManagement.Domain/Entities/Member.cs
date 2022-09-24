using GymManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Domain.Entities
{
    public class Member : BasePersonEntity
    {
        public int TrainerId { get; set; }
        public double Weight { get; set; }
        public decimal Height { get; set; }
        public Trainer Trainer { get; set; }

        public Member()
        {

        }

        public Member(DateTimeOffset createdAt, DateTimeOffset updatedAt, int id, int trainerId, string firstName, string lastName, DateTime dateOfBirth, double weight, decimal height, string phoneNumber, string email, bool status) : this()
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            TrainerId = trainerId;
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

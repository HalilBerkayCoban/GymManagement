using GymManagement.Domain.Common;

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

        public Member(DateTimeOffset createdAt, int id, int trainerId, string firstName, string lastName, DateTime dateOfBirth, double weight, decimal height, string phoneNumber, string email, bool status) : this()
        {
            Id = id;
            CreatedAt = createdAt;
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

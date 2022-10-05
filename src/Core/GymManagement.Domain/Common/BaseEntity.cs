namespace GymManagement.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public BaseEntity()
        {
        }

        public BaseEntity(int id) : this()
        {
            Id = id;
        }
    }
}

namespace GymManagement.Infrastructure.Authentication.Behaviours
{
    public interface ISecuredRequest
    {
        public string[] Roles { get; }
    }
}

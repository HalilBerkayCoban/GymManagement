namespace GymManagement.Domain.Entities
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }
}

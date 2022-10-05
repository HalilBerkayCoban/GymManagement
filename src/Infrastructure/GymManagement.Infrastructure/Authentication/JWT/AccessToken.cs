namespace GymManagement.Infrastructure.Authentication.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }
}

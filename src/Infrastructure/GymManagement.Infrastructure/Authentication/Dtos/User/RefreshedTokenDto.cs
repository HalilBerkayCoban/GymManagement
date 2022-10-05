using GymManagement.Infrastructure.Authentication.JWT;
using GymManagement.Infrastructure.Entities;

namespace GymManagement.Infrastructure.Authentication.Dtos.User
{
    public class RefreshedTokenDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}

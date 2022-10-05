using GymManagement.Infrastructure.Authentication.JWT;
using GymManagement.Infrastructure.Entities;

namespace GymManagement.Application.Interfaces.AuthService
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user);
        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    }
}

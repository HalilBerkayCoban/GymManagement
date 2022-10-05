using GymManagement.Infrastructure.Entities;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken>
    {
    }
}

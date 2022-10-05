using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Infrastructure.Entities;
using GymManagement.Persistence.Context;

namespace GymManagement.Persistence.Repositories
{
    public class RefreshTokenRepository : EntityRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

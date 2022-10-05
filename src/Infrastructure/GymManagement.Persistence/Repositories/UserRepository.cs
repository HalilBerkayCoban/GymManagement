using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Infrastructure.Entities;
using GymManagement.Persistence.Context;

namespace GymManagement.Persistence.Repositories
{
    public class UserRepository : EntityRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

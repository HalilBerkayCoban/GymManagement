using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Infrastructure.Entities;
using GymManagement.Persistence.Context;

namespace GymManagement.Persistence.Repositories
{
    public class OperationClaimRepository : EntityRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

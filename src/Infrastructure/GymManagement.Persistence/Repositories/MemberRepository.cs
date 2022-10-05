using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using GymManagement.Persistence.Context;

namespace GymManagement.Persistence.Repositories
{
    public class MemberRepository : EntityRepositoryBase<Member, BaseDbContext>, IMemberRepository
    {
        public MemberRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

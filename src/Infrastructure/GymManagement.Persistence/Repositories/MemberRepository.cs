using GymManagement.Application.Services.Repositories;
using GymManagement.Domain.Entities;
using GymManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Persistence.Repositories
{
    public class MemberRepository : EntityRepositoryBase<Member, BaseDbContext>, IMemberRepository
    {
        public MemberRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

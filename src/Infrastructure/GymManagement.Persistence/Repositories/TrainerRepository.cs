using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using GymManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Persistence.Repositories
{
    public class TrainerRepository: EntityRepositoryBase<Trainer, BaseDbContext>, ITrainerRepository
    {
        public TrainerRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

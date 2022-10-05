using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using GymManagement.Persistence.Context;

namespace GymManagement.Persistence.Repositories
{
    public class TrainerRepository: EntityRepositoryBase<Trainer, BaseDbContext>, ITrainerRepository
    {
        public TrainerRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

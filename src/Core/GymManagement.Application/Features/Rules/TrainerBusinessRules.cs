using GymManagement.Application.Exceptions;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Features.Rules
{
    public class TrainerBusinessRules: CommonBusinessRules
    {
        public async Task TrainerShouldExistWhenRequested(Trainer trainer)
        {
            if (trainer == null) throw new BusinessException("Requested trainer does not exist");
        }
    }
}

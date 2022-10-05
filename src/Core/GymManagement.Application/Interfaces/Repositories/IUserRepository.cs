using GymManagement.Infrastructure.Entities;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository: IAsyncRepository<User>
    {
    }
}

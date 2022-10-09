using GymManagement.Domain.Entities;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository: IAsyncRepository<User>
    {
    }
}

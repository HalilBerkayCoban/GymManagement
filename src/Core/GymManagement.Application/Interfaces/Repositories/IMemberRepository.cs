using GymManagement.Domain.Entities;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface IMemberRepository: IAsyncRepository<Member>, IRepository<Member>
    {
    }
}

using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Services.Repositories
{
    public interface IMemberRepository: IAsyncRepository<Member>, IRepository<Member>
    {
    }
}

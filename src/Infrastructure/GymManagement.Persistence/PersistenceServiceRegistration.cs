using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Persistence.Context;
using GymManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Persistence
{

    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<BaseDbContext>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();

            return services;
        }
    }
}

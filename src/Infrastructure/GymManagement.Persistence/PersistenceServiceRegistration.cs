using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Persistence.Context;
using GymManagement.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Persistence
{

    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<BaseDbContext>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }
    }
}

using FluentValidation;
using GymManagement.Application.Features.Rules;
using GymManagement.Application.Interfaces.AuthService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GymManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<MemberBusinessRules>();
            services.AddScoped<TrainerBusinessRules>();
            services.AddScoped<AuthBusinessRules>();

            services.AddScoped<IAuthService, AuthManager>();

            return services;
        }
    }
}

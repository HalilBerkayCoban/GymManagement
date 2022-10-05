using GymManagement.Infrastructure.Authentication.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();
            //services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
            //services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
            return services;
        }
    }
}

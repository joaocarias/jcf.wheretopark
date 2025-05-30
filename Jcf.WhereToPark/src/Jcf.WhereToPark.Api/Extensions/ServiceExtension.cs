using Jcf.WhereToPark.Api.Application.Authentication.Services;
using Jcf.WhereToPark.Api.Core.Services.IServices;

namespace Jcf.WhereToPark.Api.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
          
            return services;
        }
    }
}

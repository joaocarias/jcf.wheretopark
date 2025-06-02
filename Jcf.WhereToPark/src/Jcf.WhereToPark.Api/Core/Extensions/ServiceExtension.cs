using Jcf.WhereToPark.Api.Applications.Authentication.Services;
using Jcf.WhereToPark.Api.Applications.User.Services;
using Jcf.WhereToPark.Api.Applications.User.Services.IServices;
using Jcf.WhereToPark.Api.Core.Services.IServices;

namespace Jcf.WhereToPark.Api.Core.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
          
            return services;
        }
    }
}

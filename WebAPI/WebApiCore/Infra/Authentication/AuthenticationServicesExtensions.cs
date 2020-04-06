using Microsoft.Extensions.DependencyInjection;
using WebApiCore.Infra.Authentication.Interfaces;
using WebApiCore.Infra.Authentication.Service;

namespace WebApiCore.Infra.Authentication
{
    public static class AuthenticationServicesExtensions
    {
        public static void AddAuthenticationServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenService, TokenService>();
        }
    }
}

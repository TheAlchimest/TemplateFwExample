using Microsoft.Extensions.DependencyInjection;
using TemplateFwExample.Shared.Application.Services;
using TemplateFwExample.Shared.Configuration;

namespace TemplateFwExample.Shared.Application
{
    public static class ServiceExtensions
    {

        #region AddSharedServices
        public static IServiceCollection AddSharedServices(this IServiceCollection services,
            SystemConfiguration config)
        {
            services.AddSingleton(config);
            services.AddScoped<IUserInfoService, UserInfoService>();
            return services;
        }
        #endregion


    }
}

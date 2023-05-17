using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

using TemplateFwExample.Application.Services;
using TemplateFwExample.Shared.Application.Services;
using TemplateFwExample.Shared.Configuration;
using TemplateFwExample.Dtos;

namespace TemplateFwExample.Application
{
    public static class ServiceExtensions
    {

        #region AddAppilcationServices
        public static IServiceCollection AddAppilcationServices(this IServiceCollection services,
            string notificationUrl, SystemConfiguration config)
        {
            // Auto Mapper Configurations
            var mapperAssembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(mapperAssembly);
			
            
			services.AddScoped<IExampleCategoryService, ExampleCategoryService>();
			services.AddScoped<IExampleModelService, ExampleModelService>();
			services.AddScoped<IExampleStatusService, ExampleStatusService>();
			
            services.AddScoped<IUserInfoService, UserInfoService>();
            return services;
        }
        #endregion


    }
}

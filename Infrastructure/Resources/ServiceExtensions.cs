
using System;
using TemplateFw.Resources;
using Microsoft.AspNetCore.Builder;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
namespace TemplateFw.Resources
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterLocalization(this IServiceCollection services, IConfiguration Configuration)
        {
            return services;
        }

    }
}

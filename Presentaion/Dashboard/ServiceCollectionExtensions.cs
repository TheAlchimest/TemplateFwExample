using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /* public static IServiceCollection AddWebDependancies(this IServiceCollection services)
         {
             services.AddScoped<ICurrentUserService, CurrentUserService>();

             return services;
         }
         */
        public static IServiceCollection AddMultiLingualSupport(this IServiceCollection services)
        {
            services.AddLocalization(opts => opts.ResourcesPath = "Resources");


            

            services.Configure<RequestLocalizationOptions>(opts =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("ar"),
                    new CultureInfo("en")
                };

                opts.DefaultRequestCulture = new RequestCulture("ar", "ar");
                // Formatting numbers, dates, etc.
                opts.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                opts.SupportedUICultures = supportedCultures;
                opts.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });

            services.AddMvc()
                            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                            .AddDataAnnotationsLocalization();

            return services;
        }
    }

    public static class ApplicationBuilderExtensions
    {
        public static void UseAppRequestLocalization(this IApplicationBuilder app)
        {
            var cultureInfo = new CultureInfo("ar-EG");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


            app.UseRequestLocalization();
           
        }
    }
}

using Dashboard.Common.WebClientHelpers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Razor;
using TemplateFwExample.Dashboard.Auth;
using TemplateFwExample.Dtos;
using TemplateFwExample.Shared.Configuration;

namespace TemplateFwExample.Dashboard
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var webSettingsSection = Configuration.GetSection("WebSettings");
            services.Configure<WebSettings>(webSettingsSection);
            var webSettings = webSettingsSection.Get<WebSettings>();
            services.SetWebClientHelpersConfigurations(webSettings.ModulesInternalApiUrl);
            services.AddControllersWithViews();

            services.AddWindowsAuth();

            var config = new SystemConfiguration();
            Configuration.Bind(config);
            services.AddSingleton(config);
            
			//ExampleCategory
			services.AddTransient<ExampleCategoryDtoInsertValidator>();
			services.AddTransient<ExampleCategoryDtoUpdateValidator>();
			services.AddTransient<ExampleCategoryFilterValidator>();
			//ExampleModel
			services.AddTransient<ExampleModelDtoInsertValidator>();
			services.AddTransient<ExampleModelDtoUpdateValidator>();
			services.AddTransient<ExampleModelFilterValidator>();
			//ExampleStatus
			services.AddTransient<ExampleStatusDtoInsertValidator>();
			services.AddTransient<ExampleStatusDtoUpdateValidator>();
			services.AddTransient<ExampleStatusFilterValidator>();

            // Add Localizations
            services.AddLocalization();
            services.AddMvc(o =>
            {
                o.Conventions.Add(new AddAuthorizeFiltersControllerConvention());
            })
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IValidator>())
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization()
            .AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            #region Log

            LogConfiguration.SetLogConfiguration(Configuration);

            #endregion

            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddDataAnnotationsLocalization()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePages(sub =>
            {
                sub.Run(async context =>
                {
                    if (context.Response.StatusCode == 403)
                    {
                        context.Response.Redirect("/Home/UnauthorizedAction");
                        await Task.CompletedTask;
                    }
                });
            });
            app.UseRequestLocalization();//to support multi languages

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //
            app.UseAppRequestLocalization();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "BlockReasonNote",
                   pattern: "{controller=Home}/{action=Index}/{id?}/{foundationType?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


            });
        }
    }
}

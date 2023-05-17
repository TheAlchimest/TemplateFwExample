using FluentValidation;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Globalization;
using TemplateFwExample.Application;
using TemplateFwExample.DashboardApi.Utils;
using TemplateFwExample.Dtos;
using TemplateFwExample.Persistence;
using TemplateFwExample.Shared.Configuration;

namespace TemplateFwExample.DashboardApi
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

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins(
                            "http://localhost:25992",
                            "http://localhost:56653",
                            "http://localhost:56659",
                            "http://localhost:25300",
                            "http://localhost:44348",
                            "http://localhost:8089",
                            "https://localhost:5101",
                            "http://23.22.223.162:8089",
                            "*"
                            ).AllowAnyHeader()

                            .AllowAnyMethod(); ;
                    });
            });

            services.AddHttpContextAccessor();
            //db Persistence
            services.AddPersistence(Configuration);

            var config = new SystemConfiguration();
            Configuration.Bind(config);
            services.AddSingleton(config);

            //var options = Configuration.GetSection("ClientsOptions").Get<ClientsOptions>();
            services.AddAppilcationServices(Configuration.GetValue<string>("NotificationUrl"), config);
            services.AddLocalization(options => options.ResourcesPath = "Resources");


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TemplateFwExample.DashboardApi", Version = "v1" });
                c.OperationFilter<HeaderParameter>();
            });

            #region Log

            LogConfiguration.SetLogConfiguration(Configuration);

            #endregion

            ConfigureLocalizationOptions(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseCors();

            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TemplateFwExample.DashboardApi v1"));
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureLocalizationOptions(IServiceCollection services)
        {
            const string enUSCulture = "en-US";
            const string arQACulture = "ar-EG";

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo(arQACulture),
                    new CultureInfo(enUSCulture)
                };

                options.DefaultRequestCulture = new RequestCulture(culture: arQACulture, uiCulture: arQACulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new AcceptLanguageHeaderRequestCultureProvider()
                };
            });
        }
    }
}

using Adoler.AdoExtension.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateFwExample.Persistence.IRepositories;
using TemplateFwExample.Persistence.Persistent.Db;
using TemplateFwExample.Persistence.Repositories;
using TemplateFwExample.Shared.Helpers.SqlDataHelpers;

namespace TemplateFwExample.Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string dshboardConnection = configuration.GetSharedModulesWriteConnectionString();
            string dashboardReadOnlyConnection = configuration.GetSharedModulesReadOnlyConnectionString();


            services.AddScoped<Adoler.AdoExtension.Helpers.SqlDataHelper, Adoler.AdoExtension.Helpers.SqlDataHelper>(sp =>
            {
                return new SqlDataHelper(dshboardConnection);
            });

            services.AddScoped<SqlHelperWrite, SqlHelperWrite>(sp =>
            {
                return new SqlHelperWrite(configuration);
            });

            services.AddScoped<SqlHelperRead, SqlHelperRead>(sp =>
            {
                return new SqlHelperRead(configuration);
            });

            services.AddScoped<IDbHelper, DbHelper>();

            
			services.AddScoped<IExampleCategoryRepository, ExampleCategoryRepository>();
			services.AddScoped<IExampleModelRepository, ExampleModelRepository>();
			services.AddScoped<IExampleStatusRepository, ExampleStatusRepository>();


            return services;
        }
    }
}

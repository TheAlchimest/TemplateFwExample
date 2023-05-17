using Microsoft.Extensions.Configuration;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using TemplateFwExample.Shared.Helpers;

namespace TemplateFwExample.Shared.Configuration
{
    public class LogConfiguration
    {
        public static void SetLogConfiguration(IConfiguration configuration)
        {
            var connectionStringLog = configuration.GetValue<string>("LoggingDBConnection");
            var writeTo = configuration.GetSection("Serilog:WriteTo").Get<List<LoggingWriteTo>>();
            var msSQL = writeTo.SingleOrDefault(a => a.Name == "MSSqlServer");
            var databaseName = (msSQL == null) ? "Logs" : msSQL.Args.TableName;

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.MSSqlServer(
                connectionString: StringCipher.Decrypt(connectionStringLog),
                tableName: databaseName)
                .CreateLogger();
            Log.Information("Application Start");
        }
    }
}

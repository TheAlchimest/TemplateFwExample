using Microsoft.Extensions.Configuration;
using TemplateFwExample.Persistence.Persistent.Db;
using TemplateFwExample.Shared.Helpers.SqlDataHelpers;

namespace TemplateFwExample.Persistence.Repositories
{
    public class DbHelper : IDbHelper
    {
        public SqlHelperWrite SqlHelperWrite { get; }
        public SqlHelperRead SqlHelperRead { get; }
        public string WriteConnectionString { get; }
        public string ReadConnectionString { get; }

        public DbHelper(SqlHelperWrite dbHelperWrite, SqlHelperRead dbHelperRead, IConfiguration configuration)
        {
            SqlHelperWrite = dbHelperWrite;
            SqlHelperRead = dbHelperRead;
            WriteConnectionString = configuration.GetSharedModulesWriteConnectionString();
            ReadConnectionString = configuration.GetSharedModulesReadOnlyConnectionString();
        }

    }
}

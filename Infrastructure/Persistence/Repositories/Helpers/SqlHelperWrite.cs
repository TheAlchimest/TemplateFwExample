using Microsoft.Extensions.Configuration;
using TemplateFwExample.Shared.Helpers.SqlDataHelpers;

namespace TemplateFwExample.Persistence.Repositories
{
    public class SqlHelperWrite : Adoler.AdoExtension.Helpers.SqlDataHelper
    {
        public SqlHelperWrite(IConfiguration configuration) : base(configuration.GetSharedModulesWriteConnectionString())
        {
        }

    }
}

using Microsoft.Extensions.Configuration;
using TemplateFwExample.Shared.Helpers.SqlDataHelpers;

namespace TemplateFwExample.Persistence.Repositories
{
    public class SqlHelperRead : Adoler.AdoExtension.Helpers.SqlDataHelper
    {
        public SqlHelperRead(IConfiguration configuration) : base(configuration.GetSharedModulesReadOnlyConnectionString())
        {
        }

    }
}

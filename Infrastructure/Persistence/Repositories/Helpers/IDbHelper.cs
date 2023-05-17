using TemplateFwExample.Persistence.Persistent.Db;

namespace TemplateFwExample.Persistence.Repositories
{
    public interface IDbHelper
    {
        string ReadConnectionString { get; }
        SqlHelperRead SqlHelperRead { get; }
        SqlHelperWrite SqlHelperWrite { get; }
        string WriteConnectionString { get; }
    }
}
using Microsoft.Data.Sqlite;

namespace Contract.Helpers
{
    public interface IHelper
    {
        SqliteConnection GetDBConnection();
    }
}

using System.Data.SqlClient;

namespace Infrastructure.SqlServer.Shared
{
    public static class Database
    {
        private const string ConnectionString =
            "Server=127.0.0.1,1433;Database=sql_foods_examen;User Id=SA;Password=yourStrong(!)Password;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
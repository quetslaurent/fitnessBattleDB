using System.Data.SqlClient;

namespace Infrastructure.SqlServer.Shared
{
    public static class Database
    {
        private const string ConnectionString =
            @"Server=MSI\SQLEXPRESS;Database=sql_fitness_battle;Integrated Security=SSPI";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
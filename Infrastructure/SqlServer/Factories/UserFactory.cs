using System.Data.SqlClient;
using Domain.User;
using Infrastructure.SqlServer.User;

namespace Infrastructure.SqlServer.Factories
{
    public class UserFactory : IInstanceFromReaderFactory<IUser>
    {
        public IUser CreateFromReader(SqlDataReader reader)
        {
            return new Domain.User.User
            {
                Id = reader.GetInt32(reader.GetOrdinal(UserSqlServer.ColId)),
                Name = reader.GetString(reader.GetOrdinal(UserSqlServer.ColName)),
                Password = reader.GetString(reader.GetOrdinal(UserSqlServer.ColPassword)),
                Email = reader.GetString(reader.GetOrdinal(UserSqlServer.ColEmail)),
                Role = reader.GetString(reader.GetOrdinal(UserSqlServer.ColRole))
            };
        }
    }
}
using System.Data.SqlClient;
using Domain.Unit;
using Infrastructure.SqlServer.Unit;

namespace Infrastructure.SqlServer.Factories
{
    public class UnitFactory: IInstanceFromReaderFactory<IUnit>
    {
        public IUnit CreateFromReader(SqlDataReader reader)
        {
            return new Domain.Unit.Unit
            {
                Id = reader.GetInt32(reader.GetOrdinal(UnitSqlServer.ColId)),
                Type = reader.GetString(reader.GetOrdinal(UnitSqlServer.ColType)),
            };
        }
    }
}
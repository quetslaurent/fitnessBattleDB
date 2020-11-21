using System;
using System.Data.SqlClient;
using Domain.Activity;
using Infrastructure.SqlServer.Activity;
using Infrastructure.SqlServer.Category;
using Infrastructure.SqlServer.Unit;

namespace Infrastructure.SqlServer.Factories
{
    public class ActivityFactory : IInstanceFromReaderFactory<IActivity>
    {
        public IActivity CreateFromReader(SqlDataReader reader)
        {
            return new Domain.Activity.Activity
            {
                Id = reader.GetInt32(reader.GetOrdinal(ActivitySqlServer.ColId)),
                Name = reader.GetString(reader.GetOrdinal(ActivitySqlServer.ColName)),
                Repetitions = Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal(ActivitySqlServer.ColRepetitions))),
                
                Unit = new Domain.Unit.Unit
                {
                    Id = reader.GetInt32(reader.GetOrdinal(ActivitySqlServer.ColIdUnit)),
                    Type = reader.GetString(reader.GetOrdinal(UnitSqlServer.ColType)),
                },
                Category = new Domain.Category.Category
                {
                    Id = reader.GetInt32(reader.GetOrdinal(ActivitySqlServer.ColIdCategory)),
                    Name = reader.GetString(reader.GetOrdinal(CategorySqlServer.ColName))
                }
            };
        }
    }
}
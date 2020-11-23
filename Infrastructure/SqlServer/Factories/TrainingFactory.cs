using System;
using System.Data.SqlClient;
using Domain.Training;
using Infrastructure.SqlServer.Activity;
using Infrastructure.SqlServer.Category;
using Infrastructure.SqlServer.Training;
using Infrastructure.SqlServer.TrainingDate;
using Infrastructure.SqlServer.Unit;
using Infrastructure.SqlServer.User;

namespace Infrastructure.SqlServer.Factories
{
    public class TrainingFactory : IInstanceFromReaderFactory<ITraining>
    {
        public ITraining CreateFromReader(SqlDataReader reader)
        {
            return new Domain.Training.Training
            {
                Id = reader.GetInt32(reader.GetOrdinal(TrainingSqlServer.ColId)),
                User = new Domain.User.User
                {
                    Id = reader.GetInt32(reader.GetOrdinal(UserSqlServer.ColId)),
                    Name = reader.GetString(reader.GetOrdinal(UserSqlServer.ColName)),
                    Password = reader.GetString(reader.GetOrdinal(UserSqlServer.ColPassword)),
                    Email = reader.GetString(reader.GetOrdinal(UserSqlServer.ColEmail)),
                    Admin = reader.GetBoolean(reader.GetOrdinal(UserSqlServer.ColAdmin))
                },
                Activity = new Domain.Activity.Activity
                {
                    Id = reader.GetInt32(reader.GetOrdinal(ActivitySqlServer.ColId)),
                    Name = reader.GetString(reader.GetOrdinal(ActivitySqlServer.ColName)),
                    Category = new Domain.Category.Category
                    {
                        Id = reader.GetInt32(reader.GetOrdinal(CategorySqlServer.ColId)),
                        Name = reader.GetString(reader.GetOrdinal(ActivitySqlServer.ColName))
                    },
                    Repetitions = Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal(ActivitySqlServer.ColRepetitions))),
                    Unit = new Domain.Unit.Unit
                    {
                        Id = reader.GetInt32(reader.GetOrdinal(UnitSqlServer.ColId)),
                        Type = reader.GetString(reader.GetOrdinal(UnitSqlServer.ColType))
                    }
                },
                Repetitions = Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal(TrainingSqlServer.ColRepetitions))),
                TrainingDate = new Domain.TrainingDate.TrainingDate
                {
                    Id = reader.GetInt32(reader.GetOrdinal(TrainingDateSqlServer.ColId)),
                    Date = reader.GetDateTime(reader.GetOrdinal(TrainingDateSqlServer.ColDate))
                }
            };
        }
    }
}
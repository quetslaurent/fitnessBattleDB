using System.Collections.Generic;
using System.Data;
using Application.Repositories;
using Domain.Activity;
using Domain.TrainingDate;
using Infrastructure.SqlServer.Activity;
using Infrastructure.SqlServer.Factories;
using Infrastructure.SqlServer.Shared;
using ActivityFactory = Domain.Activity.ActivityFactory;

namespace Infrastructure.SqlServer.TrainingDate
{
    public class TrainingDateRepository : ITrainingDateRepository
    {
          private readonly IInstanceFromReaderFactory<ITrainingDate> _factory = new TrainingDateFactory();

        public IEnumerable<ITrainingDate> Query()
        {
            IList<IActivity> trainingDates = new List<IActivity>();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = TrainingDateSqlServer.ReqQuery;

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    trainingDates.Add(_factory.CreateFromReader(reader));
                }
            }

            return trainingDates;
        }

        public IActivity GetById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = ActivitySqlServer.ReqGetById;
                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColId}", id);

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    return _factory.CreateFromReader(reader);
                }
            }

            return null;
        }

        public IActivity Create(IActivity activity)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = ActivitySqlServer.ReqCreate;

                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColName}", activity.Name);
                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColRepetitions}", activity.Repetitions);
                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColIdUnit}", activity.Unit);
                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColIdCategory}", activity.Category);

                activity.Id = (int) cmd.ExecuteScalar();
            }

            return activity;
        }

        public bool Update(int id, IActivity activity)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = ActivitySqlServer.ReqPut;

                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColId}", id);
                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColName}", activity.Name);
                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColRepetitions}", activity.Repetitions);
                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColIdUnit}", activity.Unit);
                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColIdCategory}", activity.Category);


                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
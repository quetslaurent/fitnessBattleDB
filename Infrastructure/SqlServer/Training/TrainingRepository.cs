using System.Collections.Generic;
using System.Data;
using Domain.Training;
using Infrastructure.SqlServer.Factories;
using Infrastructure.SqlServer.Shared;
using TrainingFactory = Infrastructure.SqlServer.Factories.TrainingFactory;

namespace Infrastructure.SqlServer.Training
{
    public class TrainingRepository
    {
         private readonly IInstanceFromReaderFactory<ITraining> _factory = new TrainingFactory();

        public IEnumerable<ITraining> Query()
        {
            IList<ITraining> trainings = new List<ITraining>();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = TrainingSqlServer.ReqQuery;

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    trainings.Add(_factory.CreateFromReader(reader));
                }
            }

            return trainings;
        }

        public ITraining GetById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = TrainingSqlServer.ReqGetById;
                cmd.Parameters.AddWithValue($"@{TrainingSqlServer.ColId}", id);

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    return _factory.CreateFromReader(reader);
                }
            }

            return null;
        }

        public ITraining Create(ITraining training)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = TrainingSqlServer.ReqCreate;

                cmd.Parameters.AddWithValue($"@{TrainingSqlServer.ColIdTrainingDate}", training.TrainingDate.Id);
                cmd.Parameters.AddWithValue($"@{TrainingSqlServer.ColIdActivity}", training.Activity.Id);
                cmd.Parameters.AddWithValue($"@{TrainingSqlServer.ColIdUser}", training.User.Id);

                training.Id = (int) cmd.ExecuteScalar();
            }

            return training;
        }

      
    }
}
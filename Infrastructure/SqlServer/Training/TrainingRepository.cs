using System.Collections.Generic;
using System.Data;
using Application.Repositories;
using Domain.Training;
using Infrastructure.SqlServer.Factories;
using Infrastructure.SqlServer.Shared;
using TrainingFactory = Infrastructure.SqlServer.Factories.TrainingFactory;

namespace Infrastructure.SqlServer.Training
{
    public class TrainingRepository : ITrainingRepository
    {
         private readonly IInstanceFromReaderFactory<ITraining> _factory = new TrainingFactory();

        //renvoie la liste des entrainments
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
        
        //crée un training
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
                cmd.Parameters.AddWithValue($"@{TrainingSqlServer.ColRepetitions}", training.Repetitions);

                training.Id = (int) cmd.ExecuteScalar();
            }

            return training;
        }

        //supprimer un training via id
        public bool Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = TrainingSqlServer.ReqDeleteById;

                cmd.Parameters.AddWithValue($"@{TrainingSqlServer.ColId}", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        
        //renvoie un training via la date
        public IEnumerable<ITraining> GetByDateId(int dateId)
        {
            IList<ITraining> trainings = new List<ITraining>();

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = TrainingSqlServer.ReqGetByDateId;
                cmd.Parameters.AddWithValue($"@{TrainingSqlServer.ColIdTrainingDate}", dateId);

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                    trainings.Add(_factory.CreateFromReader(reader));
            }

            return trainings;
           
        }

        public IEnumerable<ITraining> GetByUserId(int userId)
        {
            IList<ITraining> trainings = new List<ITraining>();

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = TrainingSqlServer.ReqGetByUserId;
                cmd.Parameters.AddWithValue($"@{TrainingSqlServer.ColIdUser}", userId);

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                    trainings.Add(_factory.CreateFromReader(reader));
            }

            return trainings;
           
        }
        
        public int GetPointsByUser(int userId)
        {
            IList<ITraining> trainings = new List<ITraining>();

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = TrainingSqlServer.ReqGetByUserId;
                cmd.Parameters.AddWithValue($"@{TrainingSqlServer.ColIdUser}", userId);

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                    trainings.Add(_factory.CreateFromReader(reader));
            }

            return 0;
           
        }
    }
}
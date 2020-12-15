using System;
using System.Collections.Generic;
using System.Data;
using Application.Repositories;
using Domain.TrainingDate;
using Infrastructure.SqlServer.Factories;
using Infrastructure.SqlServer.Shared;
using TrainingDatesFactory = Infrastructure.SqlServer.Factories.TrainingDatesFactory;


namespace Infrastructure.SqlServer.TrainingDate
{
    public class TrainingDateRepository : ITrainingDateRepository
    {
        private readonly IInstanceFromReaderFactory<ITrainingDate> _factory = new TrainingDatesFactory();

        //renvoie la liste des trainingDates
        public IEnumerable<ITrainingDate> Query()
        {
            IList<ITrainingDate> trainingDates = new List<ITrainingDate>();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = TrainingDateSqlServer.ReqQuery;

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                    trainingDates.Add(_factory.CreateFromReader(reader));
            }

            return trainingDates;
        }

        //renvoie le trainingDate correspondant à l'id
        public ITrainingDate GetById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = TrainingDateSqlServer.ReqGetById;
                cmd.Parameters.AddWithValue($"@{TrainingDateSqlServer.ColId}", id);

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    return _factory.CreateFromReader(reader);
                }
            }

            return null;
        }

        //crée une trainingDate depuis une date
        public ITrainingDate Create(DateTime date)
        {
            var trainingDate = new Domain.TrainingDate.TrainingDate()
            {
                Date = date
            };

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = TrainingDateSqlServer.ReqCreate;

                cmd.Parameters.AddWithValue($"@{TrainingDateSqlServer.ColDate}", date);

                trainingDate.Id = (int) cmd.ExecuteScalar();
            }

            return trainingDate;
        }
    }
}
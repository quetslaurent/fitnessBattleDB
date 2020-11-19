using System.Collections.Generic;
using System.Data;
using Application.Repositories;
using Domain.Activity;
using Domain.Category;
using Domain.Unit;
using Infrastructure.SqlServer.Factories;
using Infrastructure.SqlServer.Shared;
using ActivityFactory = Infrastructure.SqlServer.Factories.ActivityFactory;

namespace Infrastructure.SqlServer.Activity
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IInstanceFromReaderFactory<IActivity> _factory = new ActivityFactory();

        /*
         * Renvoie la liste d'activité
         */
        public IEnumerable<IActivity> Query()
        {
            IList<IActivity> activities = new List<IActivity>();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = ActivitySqlServer.ReqQuery;

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    activities.Add(_factory.CreateFromReader(reader));
                }
            }

            return activities;
        }
        /*
         * Récupérer une Activité grâce à son Id
         */
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

        /*
         * Récupérer la liste des activités ayant une même categorie
         */
        public IEnumerable<IActivity> GetByCategoryId(int categoryId)
        {
            IList<IActivity> activities = new List<IActivity>();

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = ActivitySqlServer.ReqGetByCategoryId;
                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColIdCategory}", categoryId);

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                    activities.Add(_factory.CreateFromReader(reader));
            }

            return activities;
           
        }
        
        /*
         * Créer une activité
         */
        public IActivity Create(IActivity activity)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = ActivitySqlServer.ReqCreate;

                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColName}",activity.Name);
                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColRepetitions}",activity.Repetitions);
                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColIdUnit}",activity.Unit.Id);
                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColIdCategory}",activity.Category.Id);

                activity.Id = (int) cmd.ExecuteScalar();
            }
            return activity;
        }

        /*
        * Modifier une activité
        */
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

        /*
         * Supprimer une Activité
         */
        public bool Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = ActivitySqlServer.ReqDeleteById;

                cmd.Parameters.AddWithValue($"@{ActivitySqlServer.ColId}", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
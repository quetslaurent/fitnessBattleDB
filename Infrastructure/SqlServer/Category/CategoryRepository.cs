using System.Collections.Generic;
using System.Data;
using Application.Repositories;
using Domain.Category;
using Infrastructure.SqlServer.Factories;
using Infrastructure.SqlServer.Shared;
using CategoryFactory = Infrastructure.SqlServer.Factories.CategoryFactory;

namespace Infrastructure.SqlServer.Category
{
    public class CategoryRepository : ICategoryRepository
    {
         private readonly IInstanceFromReaderFactory<ICategory> _factory = new CategoryFactory();

         //renvoie la liste de categorie
        public IEnumerable<ICategory> Query()
        {
            IList<ICategory> categories = new List<ICategory>();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = CategorySqlServer.ReqQuery;

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    categories.Add(_factory.CreateFromReader(reader));
                }
            }

            return categories;
        }

        //renvoie la categorie ayant le bon id
        public ICategory GetById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = CategorySqlServer.ReqGetById;
                cmd.Parameters.AddWithValue($"@{CategorySqlServer.ColId}", id);

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    return _factory.CreateFromReader(reader);
                }
            }

            return null;
        }

        //crée une categorie
        public ICategory Create(ICategory category)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = CategorySqlServer.ReqCreate;

                cmd.Parameters.AddWithValue($"@{CategorySqlServer.ColName}", category.Name);

                category.Id = (int) cmd.ExecuteScalar();
            }

            return category;
        }

        //modifie une categorie
        public bool Update(int id, ICategory category)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = CategorySqlServer.ReqPut;

                cmd.Parameters.AddWithValue($"@{CategorySqlServer.ColId}", id);
                cmd.Parameters.AddWithValue($"@{CategorySqlServer.ColName}", category.Name);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
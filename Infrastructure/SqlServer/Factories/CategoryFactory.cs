using System;
using System.Data.SqlClient;
using Domain.Category;
using Infrastructure.SqlServer.Activity;
using Infrastructure.SqlServer.Category;

namespace Infrastructure.SqlServer.Factories
{
    public class CategoryFactory : IInstanceFromReaderFactory<ICategory>
    {
        //crée une categorie depuis le reader
        public ICategory CreateFromReader(SqlDataReader reader)
        {
            return new Domain.Category.Category
            {
                Id = reader.GetInt32(reader.GetOrdinal(CategorySqlServer.ColId)),
                Name = reader.GetString(reader.GetOrdinal(CategorySqlServer.ColName))
            };
        }
    }
}
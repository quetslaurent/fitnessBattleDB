using System;
using System.Data.SqlClient;
using Domain.Category;
using Infrastructure.SqlServer.Activity;

namespace Infrastructure.SqlServer.Factories
{
    public class CategoryFactory : IInstanceFromReaderFactory<ICategory>
    {
        public ICategory CreateFromReader(SqlDataReader reader)
        {
            return new Domain.Category.Category
            {
                Id = reader.GetInt32(reader.GetOrdinal(ActivitySqlServer.ColId)),
                Name = reader.GetString(reader.GetOrdinal(ActivitySqlServer.ColName))
            };
        }
    }
}
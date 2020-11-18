using System.Collections.Generic;
using System.Data;
using Application.Repositories;
using Domain.Unit;
using Infrastructure.SqlServer.Factories;
using Infrastructure.SqlServer.Shared;
using UnitFactory = Infrastructure.SqlServer.Factories.UnitFactory;

namespace Infrastructure.SqlServer.Unit
{
    public class UnitRepository : IUnitRepository
    {
        private readonly IInstanceFromReaderFactory<IUnit> _factory = new UnitFactory();

        public IEnumerable<IUnit> Query()
        {
            IList<IUnit> units = new List<IUnit>();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = UnitSqlServer.ReqQuery;

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    units.Add(_factory.CreateFromReader(reader));
                }
            }

            return units;
        }

        public IUnit GetById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = UnitSqlServer.ReqGetById;
                cmd.Parameters.AddWithValue($"@{UnitSqlServer.ColId}", id);

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    return _factory.CreateFromReader(reader);
                }
            }

            return null;
        }

        public IUnit Create(IUnit unit)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = UnitSqlServer.ReqCreate;

                cmd.Parameters.AddWithValue($"@{UnitSqlServer.ColType}", unit.Type);

                unit.Id = (int) cmd.ExecuteScalar();
            }

            return unit;
        }

        public bool Update(int id, IUnit unit)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = UnitSqlServer.ReqPut;

                cmd.Parameters.AddWithValue($"@{UnitSqlServer.ColId}", id);
                cmd.Parameters.AddWithValue($"@{UnitSqlServer.ColType}", unit.Type);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
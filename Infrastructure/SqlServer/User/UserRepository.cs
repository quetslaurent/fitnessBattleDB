using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Application.Repositories;
using Domain.User;
using Infrastructure.SqlServer.Factories;
using Infrastructure.SqlServer.Shared;
using UserFactory = Infrastructure.SqlServer.Factories.UserFactory;

namespace Infrastructure.SqlServer.User
{
    public class UserRepository : IUserRepository
    {
         private readonly IInstanceFromReaderFactory<IUser> _factory = new UserFactory();

        public IEnumerable<IUser> Query()
        {
            IList<IUser> users = new List<IUser>();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = UserSqlServer.ReqQuery;

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    users.Add(_factory.CreateFromReader(reader));
                }
            }

            return users;
        }

        public IUser GetById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = UserSqlServer.ReqGetById;
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColId}", id);

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    return _factory.CreateFromReader(reader);
                }
            }

            return null;
        }
        
        public string HashPassword(string password)
        {
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes(password);

                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);

                // Convert hash byte array to string
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                // Output the MD5 hash
                return hash;
            }
        }
        
        public IUser Create(IUser user)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = UserSqlServer.ReqCreate;

                user.Password = HashPassword(user.Password);
                
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColName}", user.Name);
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColAdmin}", user.Admin);
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColEmail}", user.Email);
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColPassword}", user.Password);


                user.Id = (int) cmd.ExecuteScalar();
            }

            return user;
        }
    }
}
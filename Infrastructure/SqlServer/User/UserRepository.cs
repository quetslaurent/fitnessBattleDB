﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Application.Repositories;
using Domain.User;
using Infrastructure.SqlServer.Factories;
using Infrastructure.SqlServer.Shared;
using Infrastructure.SqlServer.Training;
using UserFactory = Infrastructure.SqlServer.Factories.UserFactory;

namespace Infrastructure.SqlServer.User
{
    public class UserRepository : IUserRepository
    {
         private readonly IInstanceFromReaderFactory<IUser> _factory = new UserFactory();

        //renvoie la liste des users 
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

        //renvoie l'user ayant l'id de l'argument
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

        //hash le password grâce a SHA256
        public string HashPassword(string password)
        {
            return ComputeHash(password, new SHA256CryptoServiceProvider()).Replace("-", String.Empty);
        }

        //modifie l'user
        public bool Update(int id, IUser user)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = UserSqlServer.ReqPut;

                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColId}", id);
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColName}", user.Name);
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColEmail}", user.Email);
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColPassword}", user.Password);
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColRole}", user.Role);


                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //supprimer un user
        public bool Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = UserSqlServer.ReqDeleteById;

                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColId}", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //permet de hash
        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        //créer un user
        public IUser Create(IUser user)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = UserSqlServer.ReqCreate;

                user.Password = HashPassword(user.Password);
                
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColName}", user.Name);
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColRole}", user.Role);
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColEmail}", user.Email);
                cmd.Parameters.AddWithValue($"@{UserSqlServer.ColPassword}", user.Password);


                user.Id = (int) cmd.ExecuteScalar();
            }

            return user;
        }

        //renvoie les points d'un user
        public double GetPointsById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = TrainingSqlServer.ReqGetPointsByUserId;
                cmd.Parameters.AddWithValue($"@{TrainingSqlServer.ColIdUser}", id);

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    return Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal(TrainingSqlServer.ColPoints)));
                }

                return 0;
            }
        }
    }
}
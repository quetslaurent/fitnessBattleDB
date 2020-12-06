using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Application.Repositories;
using Application.Services.Category.Dto;
using Application.Services.User.Dto;
using Domain.User;

namespace Application.Services.User
{
    public class UserService : IUserService
    {
        //repository et factory
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFactory = new UserFactory();

        //constructeur
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<OutputDtoQueryUser> Query()
        {
            /*
             * On récupère les categories pour les renvoyer
             * en format DTO
             */
            return _userRepository
                .Query()
                .Select(user => new OutputDtoQueryUser
                {
                    Id = user.Id,
                    Name = user.Name,
                    Role = user.Role,
                    Email = user.Email,
                    Password = user.Password,
                    Points = _userRepository.GetPointsById(user.Id)
                }).OrderByDescending(user => user.Points);
        }

        public OutputDtoAddUser Create(InputDtoAddUser inputDtoAddUser)
        {
            //DTO --> Domain
            var userFromDto = _userFactory.CreateUserFromValues(inputDtoAddUser.Name,inputDtoAddUser.Password,inputDtoAddUser.Email,"user");
            //Repository demande un element du domain

            var usersInDb = _userRepository.Query();
            foreach (var user in usersInDb)
            {
                if (user.Email == userFromDto.Email || user.Name == userFromDto.Name)
                    throw new Exception("User already in database");
            }
            //On crée l'utilisateur
            var userInDb = _userRepository.Create(userFromDto);
            
            //Domain -> DTO
            return new OutputDtoAddUser
            {
                Id = userInDb.Id,
                Name = userInDb.Name,
                Role = userInDb.Role,
                Email = userInDb.Email,
                Password = userInDb.Password
            };
        }

        public double GetUserPointsById(int id)
        {
            return _userRepository.GetPointsById(id);
        }

        public OutputDtoQueryUser GetUserById(int id)
        {
            var userInDb = _userRepository.GetById(id);
            return new OutputDtoQueryUser
            {
                Id = userInDb.Id,
                Name = userInDb.Name,
                Role = userInDb.Role,
                Email = userInDb.Email,
                Password = userInDb.Password,
                Points = _userRepository.GetPointsById(userInDb.Id)
            };
        }

        public string HashPassword(string password)
        {
            return _userRepository.HashPassword(password);
        }

        public bool Update(int id, InputDtoUpdateUser inputDtoUpdateUser)
        {
            var userFromDto = _userFactory.CreateUserFromValues(
                inputDtoUpdateUser.Name,
                HashPassword(inputDtoUpdateUser.Password),
                inputDtoUpdateUser.Email,
                inputDtoUpdateUser.Role
                );
            return _userRepository.Update(id,userFromDto);
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.Delete(id);
        }
    }
}
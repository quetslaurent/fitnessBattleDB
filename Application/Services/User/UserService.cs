using System.Collections.Generic;
using System.Linq;
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
                    Admin = user.Admin,
                    Email = user.Email,
                    Password = user.Password
                });
        }

        public OutputDtoAddUser Create(InputDtoAddUser inputDtoAddUser)
        {
            //DTO --> Domain
            var userFromDto = _userFactory.CreateUserFromValues(inputDtoAddUser.Name,inputDtoAddUser.Password,inputDtoAddUser.Email,inputDtoAddUser.Admin);
            //Repository demande un element du domain
            var userInDb = _userRepository.Create(userFromDto);
            
            //Domain -> DTO
            return new OutputDtoAddUser
            {
                Id = userInDb.Id,
                Name = userInDb.Name,
                Admin = userInDb.Admin,
                Email = userInDb.Email,
                Password = userInDb.Password
            };
        }
    }
}
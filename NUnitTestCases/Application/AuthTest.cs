using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Auth;
using Application.Services.Auth.Dto;
using Application.Services.User;
using Application.Services.User.Dto;
using Domain.User;
using FitnessBattle.TokenManager;
using NSubstitute;
using NUnit.Framework;

namespace NUnitTestCases.Application
{
    [TestFixture]
    public class AuthTest
    {
        private static readonly  IUserService _userService = Substitute.For<IUserService>();
        private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
        private static readonly ITokenManager _tokenManager = Substitute.For<ITokenManager>();
        
        private readonly IAuthService _authService = new AuthService(_userService,_tokenManager);

        
        private static IEnumerable<OutputDtoQueryUser> getUserOutputDtoList()
        {
            OutputDtoQueryUser[] users =
            {
                new OutputDtoQueryUser("name","password","email","user")
            };
            IEnumerable <OutputDtoQueryUser> list= users;
            return list;
        }
        
        [Test]
        public void Login_InputDtoAuthUser_NotNull()
        {
            InputDtoAuthUser input = new InputDtoAuthUser
            {
                Name = "name",
                Password = "password"
            };

            
            _userService.Query().Returns(getUserOutputDtoList());
            
            _userService.HashPassword("password")
                .Returns("password");

            var userInDb = new User("name", "password", "email", "user");

            _tokenManager.GenerateJwtToken(
                new OutputDtoQueryUser(userInDb.Name,userInDb.Password,userInDb.Email,userInDb.Role)
                ).Returns("token");

            var res = _authService.Login(input);

            Assert.NotNull(res);
        }
        
        [Test]
        public void Login_InputDtoAuthUser_NotEmpty()
        {
            InputDtoAuthUser input = new InputDtoAuthUser
            {
                Name = "name",
                Password = "password"
            };

            
            _userService.Query().Returns(getUserOutputDtoList());
            
            _userService.HashPassword("password")
                .Returns("password");

            var userInDb = new User("name", "password", "email", "user");

            _tokenManager.GenerateJwtToken(
                new OutputDtoQueryUser(userInDb.Name,userInDb.Password,userInDb.Email,userInDb.Role)
            ).Returns("token");

            var res = _authService.Login(input);

            Assert.IsNotEmpty(res.Token);
        }
        
        [Test]
        public void Login_InputDtoAuthUser_AreSame()
        {
            InputDtoAuthUser input = new InputDtoAuthUser
            {
                Name = "name",
                Password = "password"
            };

            _userService.Query().Returns(getUserOutputDtoList());
            
            _userService.HashPassword("password")
                .Returns("password");

            var userInDb = new User("name", "password", "email", "user");

            _tokenManager.GenerateJwtToken(
                new OutputDtoQueryUser(userInDb.Name,userInDb.Password,userInDb.Email,userInDb.Role)
            ).Returns("token");

            var res = _authService.Login(input);

            var expected = new OutputDtoAuthUser
            {
                Token = "token"
            };

            Assert.AreEqual(expected,res);
        }
        
        [Test]
        public void Login_InputDtoAuthUser_AreNotSame()
        {
            InputDtoAuthUser input = new InputDtoAuthUser
            {
                Name = "name",
                Password = "password"
            };

            _userService.Query().Returns(getUserOutputDtoList());
            
            _userService.HashPassword("password")
                .Returns("password");

            var userInDb = new User("name", "password", "email", "user");

            _tokenManager.GenerateJwtToken(
                new OutputDtoQueryUser(userInDb.Name,userInDb.Password,userInDb.Email,userInDb.Role)
            ).Returns("token");

            var res = _authService.Login(input);

            var expected = new OutputDtoAuthUser
            {
                Token = "otherToken"
            };

            Assert.AreNotEqual(expected,res);
        }
        
    }
}
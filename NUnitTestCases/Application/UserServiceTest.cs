using System;
using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Category.Dto;
using Application.Services.Unit;
using Application.Services.User;
using Application.Services.User.Dto;
using Domain.Category;
using Domain.Unit;
using Domain.User;
using NSubstitute;
using NUnit.Framework;

namespace NUnitTestCases.Application
{
    [TestFixture]
    public class UserServiceTest
    {
        private static IUserRepository _userRepository = Substitute.For<IUserRepository>();
        private  IUserFactory _userFactory = Substitute.For<IUserFactory>();
        private UserService _userService = new UserService(_userRepository);
        
        private static IEnumerable<IUser> getUserList()
        {
            User[] users = { new User("name","password","email","user") };
            IEnumerable <IUser> list= users;
            return list;
        }
        
        //QUERY

        [Test]
        public void Query_NotNull()
        {
            _userRepository.Query().Returns(getUserList());
            var res = _userService.Query();
            Assert.NotNull(res);
        }
        
        [Test]
        public void Query_AreSame()
        {
            _userRepository.Query().Returns(getUserList());
            var res = _userService.Query();
            
            OutputDtoQueryUser[] outputDtoQueryUsers = { new OutputDtoQueryUser("name","password","email","user") };
            IEnumerable<OutputDtoQueryUser> expected = outputDtoQueryUsers;
            Assert.IsTrue(res.SequenceEqual(expected));
        }
        
        [Test]
        public void Query_AreNotSame()
        {
            _userRepository.Query().Returns(getUserList());
            var res = _userService.Query();
            
            OutputDtoQueryUser[] outputDtoQueryUsers = { new OutputDtoQueryUser("otherName","password","email","user") };
            IEnumerable<OutputDtoQueryUser> expected = outputDtoQueryUsers;
            Assert.IsFalse(res.SequenceEqual(expected));
        }
        
        //GetUserPointsById
        
        [Test]
        public void GetUserPointsById_NotNull()
        {
            var res = _userService.GetUserPointsById(1);
            Assert.NotNull(res);
        }
       
        [Test]
        public void GetUserPointsById_AreSame()
        {
            var res = _userService.GetUserPointsById(1);
            
            OutputDtoQueryUser outputDtoQueryUser = new OutputDtoQueryUser("name", "password", "email", "user");
            outputDtoQueryUser.Id = 1;
            double expected = outputDtoQueryUser.Points;
            Assert.AreEqual(res, expected);
        }
        
        [Test]
        public void GetUserPointsById_AreNotSame()
        {
            var res = _userService.GetUserPointsById(1);
            
            OutputDtoQueryUser outputDtoQueryUser = new OutputDtoQueryUser("name", "password", "email", "user");
            outputDtoQueryUser.Id = 1;
            outputDtoQueryUser.Points = 10;
            double expected = outputDtoQueryUser.Points;
            Assert.AreNotEqual(res, expected);
        }
        
        //GetUserById
        
        [Test]
        public void GetUserById_NotNull()
        {
            _userRepository.GetById(1).Returns(new User(1,"name", "password", "email", "user"));
            var res = _userService.GetUserById(1);
            Assert.NotNull(res);
        }
       
        [Test]
        public void GetUserById_AreSame()
        {
            _userRepository.GetById(1).Returns(new User(1,"name", "password", "email", "user"));
            var res = _userService.GetUserById(1);
            
            OutputDtoQueryUser expected = new OutputDtoQueryUser("name", "password", "email", "user");
            expected.Id = 1;
            Assert.AreEqual(res, expected);
        }
        
        [Test]
        public void GetUserById_AreNotSame()
        {
            _userRepository.GetById(1).Returns(new User(1,"name", "password", "email", "user"));
            var res = _userService.GetUserById(1);

            OutputDtoQueryUser expected = new OutputDtoQueryUser("otherName", "password", "email", "user");
            expected.Id = 1;
            Assert.AreNotEqual(res, expected);
        }
        
        //HashPassword
        
        [Test]
        public void HashPassword_Password_NotEmpty()
        {
            _userRepository.HashPassword("password")
                .Returns("5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8");
            var res = _userService.HashPassword("password");
            Assert.IsNotEmpty(res);
        }
        
        [Test]
        public void HashPassword_Password_AreNotSame()
        {
            _userRepository.HashPassword("password")
                .Returns("5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8");
            var res = _userService.HashPassword("password");
            var expected = "password"; 
            Assert.AreNotEqual(expected,res);
        }
        
        [Test]
        public void HashPassword_Password_IsHashed()
        {
            _userRepository.HashPassword("password")
                .Returns("5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8");
            var res = _userService.HashPassword("password");
            var expected = "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8"; 
            Assert.AreEqual(expected,res);
        }
        
        //Update
        
        /*
        [Test]
        public void Update_InputDtoAddUser_AreSame()
        {
            var inputUpdate= new InputDtoUpdateUser("nameUserUpdated","password","emailUser","user");
            _userFactory.CreateUserFromValues(inputUpdate.Name,inputUpdate.Password,inputUpdate.Email, "user").Returns(new User(inputUpdate.Name,inputUpdate.Password,inputUpdate.Email, "user"));
            var iuserUpdated = _userFactory.CreateUserFromValues(inputUpdate.Name,inputUpdate.Password,inputUpdate.Email, "user");
            _userRepository.Query().Returns(getUserList());
            _userRepository.Create(iuserUpdated).Returns(new User(inputUpdate.Name,inputUpdate.Password,inputUpdate.Email, "user"));
            _userRepository.Update(1, iuserUpdated).Returns(true);
            
            var res = _userService.Update(1,inputUpdate);
            var expected = true;
            Assert.AreEqual(expected, res);
        }*/
        
        //CREATE

        [Test]
        public void Create_InputDtoAddUser_AreSame()
        {
            
            var input= new InputDtoAddUser("nameUser","password","emailUser");
            _userFactory.CreateUserFromValues(input.Name,input.Password,input.Email, "user").Returns(new User(input.Name,input.Password,input.Email, "user"));
            var iuser = _userFactory.CreateUserFromValues(input.Name,input.Password,input.Email, "user");
            _userRepository.Query().Returns(getUserList());
            _userRepository.Create(iuser).Returns(new User(input.Name,input.Password,input.Email, "user"));
            
            var res = _userService.Create(input);
            
            var expected = new OutputDtoAddUser("nameUser","password","emailUser","user");
            Assert.AreEqual(expected, res);

        }
        
        
        //EXCEPTION already in DB
        
        [Test]
        public void Create_InputDtoAddUser_ThrowsAlreadyInDBException()
        {
            var input= new InputDtoAddUser("name","password","email");
            _userFactory.CreateUserFromValues(input.Name,input.Password,input.Email, "user").Returns(new User(input.Name,input.Password,input.Email, "user"));
            _userRepository.Query().Returns(getUserList());
            
            var exception = Assert.Throws<Exception>(() => _userService.Create(input));
            Assert.AreEqual("User already in database",exception.Message);
        }
    }
}
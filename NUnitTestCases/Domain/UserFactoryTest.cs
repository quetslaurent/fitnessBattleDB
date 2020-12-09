using Domain.User;
using NUnit.Framework;

namespace NUnitTestCases.Domain
{
    [TestFixture]
    public class UserFactoryTest
    {
        private UserFactory _userFactory = new UserFactory();

        [Test]
        [TestCase("name","password","email","role")]
        public void CreateUserFromValues_NamePasswordEmailRole_UserAreSame(string name, string password, string email, string role)
        {
            var res = _userFactory.CreateUserFromValues(name, password, email, role);
            IUser user = new User(name, password, email, role);
            Assert.AreEqual(user,res);
        }
        
        [Test]
        [TestCase("name","password","email","role")]
        public void CreateUserFromValues_NamePasswordEmailRole_UserNotSame(string name, string password, string email, string role)
        {
            var res = _userFactory.CreateUserFromValues(name, password, email, role);
            IUser user = new User("otherUserName", password, email, role);
            Assert.AreNotEqual(user,res);
        }
        
        
    }
}
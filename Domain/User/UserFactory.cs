namespace Domain.User
{
    public class UserFactory : IUserFactory
    {
        public IUser CreateUserFromValues(string name, string password, string email, bool admin)
        {
            return new User
            {
                Name = name,
                Password = password,
                Email = email,
                Admin = admin
            };
        }
    }
}
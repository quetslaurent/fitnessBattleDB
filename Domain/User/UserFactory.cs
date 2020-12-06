namespace Domain.User
{
    public class UserFactory : IUserFactory
    {
        public IUser CreateUserFromValues(string name, string password, string email, string role)
        {
            return new User
            {
                Name = name,
                Password = password,
                Email = email,
                Role = role
            };
        }
    }
}
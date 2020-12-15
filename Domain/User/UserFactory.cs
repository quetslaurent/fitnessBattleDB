namespace Domain.User
{
    public class UserFactory : IUserFactory
    {
        //crée un user depuis les valeurs passées en argument
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
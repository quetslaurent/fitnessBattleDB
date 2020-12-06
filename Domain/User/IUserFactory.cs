namespace Domain.User
{
    public interface IUserFactory
    {
        IUser CreateUserFromValues(string name, string password, string email, string role);
    }
}
using Domain.Shared;

namespace Domain.User
{
    public interface IUser : IEntity
    {
        string Name { get; set; }
        string Password { get; set; }
        string Email { get; set; }
        string Role { get; set; }
    }
}
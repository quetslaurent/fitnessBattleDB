using System;

namespace Domain.User
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public User()
        {
            
        }

        public User(string name, string password, string email, string role)
        {
            Name = name;
            Password = password;
            Email = email;
            Role = role;
        }

        protected bool Equals(User other)
        {
            return Id == other.Id && Name == other.Name && Password == other.Password && Email == other.Email && Role == other.Role;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }
    }
}
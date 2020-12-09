using System;

namespace Application.Services.TokenManager.Dto
{
    public class OutputDtoTokenUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public OutputDtoTokenUser()
        {
        }

        public OutputDtoTokenUser(string name, string email, string role)
        {
            Name = name;
            Email = email;
            Role = role;
        }


        protected bool Equals(OutputDtoTokenUser other)
        {
            return Name == other.Name && Email == other.Email && Role == other.Role;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoTokenUser) obj);
        }
        
    }
}
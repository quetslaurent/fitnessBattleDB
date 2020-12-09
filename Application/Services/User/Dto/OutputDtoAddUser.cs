namespace Application.Services.User.Dto
{
    public class OutputDtoAddUser
    {
        public int Id { get; set; } // le retour renvoie aussi l'id
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public OutputDtoAddUser()
        {
        }
        public OutputDtoAddUser(string name, string password, string email, string role)
        {
            Name = name;
            Password = password;
            Email = email;
            Role = role;
        }

        protected bool Equals(OutputDtoAddUser other)
        {
            return Id == other.Id && Name == other.Name && Password == other.Password && Email == other.Email && Role == other.Role;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoAddUser) obj);
        }
    }
}
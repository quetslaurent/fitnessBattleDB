namespace Application.Services.User.Dto
{
    public class OutputDtoQueryUser
    {
        public int Id { get; set; } // le retour renvoie aussi l'id
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        
        public double Points { get; set; }

        public OutputDtoQueryUser()
        {
        }

        public OutputDtoQueryUser(string name, string password, string email, string role)
        {
            Name = name;
            Password = password;
            Email = email;
            Role = role;
        }

        protected bool Equals(OutputDtoQueryUser other)
        {
            return Id == other.Id && Name == other.Name && Password == other.Password && Email == other.Email && Role == other.Role && Points.Equals(other.Points);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoQueryUser) obj);
        }
    }
}
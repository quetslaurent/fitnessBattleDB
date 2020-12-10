namespace Application.Services.User.Dto
{
    public class InputDtoUpdateUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public InputDtoUpdateUser(string name, string password, string email, string role)
        {
            Name = name;
            Password = password;
            Email = email;
            Role = role;
        }

        public InputDtoUpdateUser()
        {
        }
    }
}
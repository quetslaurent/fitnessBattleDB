using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Application.Services.User.Dto
{
    public class InputDtoUpdateUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
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
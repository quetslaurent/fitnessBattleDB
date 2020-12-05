using System.Collections.Generic;
using Application.Services.User;
using Application.Services.User.Dto;
namespace Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenManager _tokenManager;

        public AuthService(IUserService userService, ITokenManager tokenManager)
        {
            _userService = userService;
            _tokenManager = tokenManager;
        }

        public OutputDtoAuthUser Login(InputDtoAuthUser user)
        {
            //on regarde si l'user qu'on envoie correspond à un utilisateur : admin/password
            IEnumerable<OutputDtoQueryUser> users = _userService.Query();

            var password = _userService.HashPassword(user.Password);
            
            foreach (var userInDb in users)
            {
                if (user.Name.Equals(userInDb.Name) && password.Equals(userInDb.Password))
                {
                    var token = _tokenManager.GenerateJwtToken(userInDb);
                    return 
                        new OutputDtoAuthUser
                        {
                            Token = token
                        };
                }
            }

            return null;
        }
    }
}
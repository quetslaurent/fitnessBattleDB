using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Services.User;
using Application.Services.User.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<OutputDtoQueryUser> Query()
        {
            return Ok(_userService.Query());
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OutputDtoQueryUser> GetUserById(int id)
        {
            return Ok(_userService.GetUserById(id));
        }
        
        [HttpGet]
        [Route("points/{id:int}")]
        public ActionResult<double> GetUserPointsById(int id)
        {
            return Ok(_userService.GetUserPointsById(id));
        }

        [HttpPost]
        public ActionResult<OutputDtoAddUser> Post([FromBody] InputDtoAddUser inputDtoAddUser)
        {
            return Ok(_userService.Create(inputDtoAddUser));
        }
        
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] InputDtoAddUser user)
        {
            //on regarde si l'user qu'on envoie correspond à un utilisateur : admin/password
            IEnumerable<OutputDtoQueryUser> users = _userService.Query();

            var password = _userService.HashPassword(user.Password);
            
            foreach (var userInDb in users)
            {
                if (user.Name.Equals(userInDb.Name) && password.Equals(userInDb.Password))
                {
                    var token = GenerateJwtToken(user);
                    return Ok(token);
                }
            }
            
            return BadRequest("Invalid user");
        }

        private string GenerateJwtToken(InputDtoAddUser user)
        {
            //on va chercher le "secret" qu'on a configurer dans appsettings.json
            var securityKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);

            //on récupère ce qu'on veut utiliser pour créer le token
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.Name,user.Name)
            };

            //on précise quel algorithme on doit utiliser
            var credentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256);

            //on crée le token en spécifiant l'émetteur, les valeurs à utiliser, la date d'expiration, l'agorithme
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials);

            //on renvoie le token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Application.Services.User.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FitnessBattle.TokenManager
{
    public class TokenManager : ITokenManager
    {
        private JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        private IConfiguration _configuration;
        public TokenManager( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //get the id from the token
        public int GetIdFromToken(string token)
        {
            var tokenBody = handler.ReadJwtToken(token);
            return Int32.Parse((tokenBody.Claims.Where(c =>c.Type == ClaimTypes.NameIdentifier)).First().Value);
        }
        
        //generate a token
        public string GenerateJwtToken(OutputDtoQueryUser user)
        {
            //on va chercher le "secret" qu'on a configurer dans appsettings.json
            var securityKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);

            //on récupère ce qu'on veut utiliser pour créer le token
            var claims = new Claim[] {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Admin.ToString())
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
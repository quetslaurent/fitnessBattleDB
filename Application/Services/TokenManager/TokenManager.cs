using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Application.Services.User.Dto;
using FitnessBattle.TokenManager;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.TokenManager
{
    public class TokenManager : ITokenManager
    {
        private readonly JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();
        public TokenManager( )
        {
        }

        //get the id from the token
        public int GetIdFromToken(string token)
        {
            var tokenBody = _handler.ReadJwtToken(token);
            return int.Parse((tokenBody.Claims.Where(c =>c.Type == ClaimTypes.NameIdentifier)).First().Value);
        }
        
        //get the name from the token
        public string GetNameFromToken(string token)
        {
            var tokenBody = _handler.ReadJwtToken(token);
            return (tokenBody.Claims.Where(c =>c.Type == ClaimTypes.Name)).First().Value;
        }
        
        //get the email from the token
        public string GetEmailFromToken(string token)
        {
            var tokenBody = _handler.ReadJwtToken(token);
            return (tokenBody.Claims.Where(c =>c.Type == ClaimTypes.Email)).First().Value;
        }
        
        //get the role from the token
        public string GetRoleFromToken(string token)
        {
            var tokenBody = _handler.ReadJwtToken(token);
            return (tokenBody.Claims.Where(c =>c.Type == ClaimTypes.Role)).First().Value;
        }
        
        //generate a token
        public string GenerateJwtToken(OutputDtoQueryUser user)
        {
            //on va chercher le "secret" qu'on a configurer dans appsettings.json
            var securityKey = Encoding.UTF8.GetBytes("WOOOOOaaawWWWWW cest Mr Palermo qui lit ce secret WWWWaaaaAaaaa");

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
            var token = new JwtSecurityToken("FitnessBattle",
                "FitnessBattle",
                claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials);

            //on renvoie le token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        
    }
}
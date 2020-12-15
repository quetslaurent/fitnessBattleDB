

using Application.Services.TokenManager.Dto;
using FitnessBattle.TokenManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
     [ApiController]
     [Route("api/token")]
     [Authorize]
    public class TokenController : ControllerBase
    {
        private readonly ITokenManager _tokenManager;

        public TokenController(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        //renvoie l'utilisateur correspondant au token
        [HttpGet]
        [Route("{token}")]
        public ActionResult<OutputDtoTokenUser> GetUserFromToken(string token)
        {
            return Ok(_tokenManager.GetUserFromToken(token));
        }
        
        
    }
}
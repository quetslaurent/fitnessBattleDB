

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

        [HttpGet]
        [Route("name/{token}")]
        public ActionResult<string> GetNameFromToken(string token)
        {
            return Ok(_tokenManager.GetNameFromToken(token));
        }
        
        [HttpGet]
        [Route("email/{token}")]
        public ActionResult<string> GetEmailFromToken(string token)
        {
            return Ok(_tokenManager.GetEmailFromToken(token));
        }
        
        [HttpGet]
        [Route("role/{token}")]
        public ActionResult<string> GetRoleFromToken(string token)
        {
            return Ok(_tokenManager.GetRoleFromToken(token));
        }
        
        
        
        
    }
}
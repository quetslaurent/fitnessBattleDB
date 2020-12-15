
using Application.Services.Auth;
using Application.Services.Auth.Dto;
using Application.Services.User.Dto;
using Microsoft.AspNetCore.Mvc;


namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        //permet a un user de se connecter
        [HttpPost]
        public ActionResult<OutputDtoAuthUser> Login([FromBody] InputDtoAuthUser user)
        {
            OutputDtoAuthUser authUser= _authService.Login(user);
            
            if (authUser != null)
            {
                return Ok(authUser);
            }
            return BadRequest("Invalid user");
            
            
        }
        
    }
}
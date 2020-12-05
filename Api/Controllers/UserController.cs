using Application.Services.User;
using Application.Services.User.Dto;
using FitnessBattle.TokenManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenManager _tokenManager;

        public UserController(IUserService userService, ITokenManager tokenManager)
        {
            _userService = userService;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        public ActionResult<OutputDtoQueryUser> Query()
        {
            return Ok(_userService.Query());
        }
        
        [HttpGet]
        [Route("{token}")]
        [Authorize]
        public ActionResult<OutputDtoQueryUser> GetUserById(string token)
        {
            return Ok(_userService.GetUserById(_tokenManager.GetIdFromToken(token)));
        }
        
        [HttpGet]
        [Route("points/{token}")]
        [Authorize]
        public ActionResult<double> GetUserPointsById(string token)
        {
            return Ok(_userService.GetUserPointsById(_tokenManager.GetIdFromToken(token)));
        }

        [HttpPost]
        public ActionResult<OutputDtoAddUser> Post([FromBody] InputDtoAddUser inputDtoAddUser)
        {
            return Ok(_userService.Create(inputDtoAddUser));
        }
        
        [HttpPut]
        [Route("{token}")]
        [Authorize]
        public ActionResult Update(string token, InputDtoUpdateUser inputDtoUpdateUser)
        {
            if(_userService.Update(_tokenManager.GetIdFromToken(token),inputDtoUpdateUser))
            {
                return Ok();
            }

            return NotFound();
        }
        
        [HttpDelete]
        [Route("{token}")]
        [Authorize]
        public ActionResult SelfDelete(string token)
        {
            if (_userService.DeleteUser(_tokenManager.GetIdFromToken(token)))
            {
                return Ok();
            }

            return NotFound();
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (_userService.DeleteUser(id))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
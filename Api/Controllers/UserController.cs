
using Application.Services.User;
using Application.Services.User.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
        
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult Update(int id, InputDtoUpdateUser inputDtoUpdateUser)
        {
            if(_userService.Update(id,inputDtoUpdateUser))
            {
                return Ok();
            }

            return NotFound();
        }
        
        [HttpDelete]
        [Route("{id:int}")]
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
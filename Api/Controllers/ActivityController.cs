﻿
using Application.Services.Activity;
using Application.Services.Activity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/activity")]
    [Authorize(Roles = "admin")]
    
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public ActionResult<OutputDtoQueryActivity> query()
        {
            return Ok(_activityService.Query());
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OutputDtoQueryActivity> GetByCategoryId(int id)
         {
             return Ok(_activityService.GetByCategoryId(id));
         }
        
        [HttpPost]
        public ActionResult<OutputDtoAddActivity> Post([FromBody] InputDtoAddActivity inputDtoAddActivity)
        {
            return Ok(_activityService.Create(inputDtoAddActivity));
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult Update(int id, InputDtoUpdateActivity inputDtoUpdateActivity)
        {
            if(_activityService.Update(id,inputDtoUpdateActivity))
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (_activityService.DeleteActivity(id))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
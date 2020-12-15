
using Application.Services.Activity;
using Application.Services.Activity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/activity")]
    [Authorize]
    
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        //renvoie la liste des activités
        [HttpGet]
        public ActionResult<OutputDtoQueryActivity> query()
        {
            return Ok(_activityService.Query());
        }
        
        //renvoie les activités appartenant a la categorie
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OutputDtoQueryActivity> GetByCategoryId(int id)
         {
             return Ok(_activityService.GetByCategoryId(id));
         }
        
        //créer une nouvelle activité si le user est admin
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult<OutputDtoAddActivity> Post([FromBody] InputDtoAddActivity inputDtoAddActivity)
        {
            return Ok(_activityService.Create(inputDtoAddActivity));
        }

        //permet de modifier une activité si le user est admin
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "admin")]
        public ActionResult Update(int id, InputDtoUpdateActivity inputDtoUpdateActivity)
        {
            if(_activityService.Update(id,inputDtoUpdateActivity))
            {
                return Ok();
            }

            return NotFound();
        }
        
        
        //permet de supprimer une activité si l'user est admin
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "admin")]
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
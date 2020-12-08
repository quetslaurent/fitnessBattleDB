using Application.Services.TrainingDate;
using Application.Services.TrainingDate.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/training-dates")]
    [Authorize]
    public class TrainingDateController : ControllerBase
    {
        private readonly ITrainingDateService _trainingDateService;

        public TrainingDateController(ITrainingDateService trainingDateService )
        {
            _trainingDateService = trainingDateService;
        }

        [HttpGet]
        public ActionResult<OutputDtoQueryTrainingDate> Query()
        {
            return Ok(_trainingDateService.Query());
        }

        [HttpPost]
        public ActionResult<OutputDtoAddTrainingDate> Post([FromBody] InputDtoAddTrainingDate inputDtoAddTrainingDate)
        {
            return Ok(_trainingDateService.Create(inputDtoAddTrainingDate));
        }
        
        [HttpPost]
        [Route("today")]
        public ActionResult<OutputDtoAddTrainingDate> Post()
        {
            return Ok(_trainingDateService.CreateToday());
        }
    }
}
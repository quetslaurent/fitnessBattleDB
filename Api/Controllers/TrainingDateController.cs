using Application.Services.Training;
using Application.Services.Training.Dto;
using Application.Services.TrainingDate;
using Application.Services.TrainingDate.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/training-dates")]
    public class TrainingDateController : ControllerBase
    {
        private readonly ITrainingDateService _trainingDateService;
        private readonly ITrainingService _trainingService;

        public TrainingDateController(ITrainingDateService trainingDateService, ITrainingService trainingService)
        {
            _trainingDateService = trainingDateService;
            _trainingService = trainingService;
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
    }
}
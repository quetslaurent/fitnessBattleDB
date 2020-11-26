using Application.Services.Training;
using Application.Services.Training.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/training")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }
        
        [HttpGet]
        [Route("date/{idTrainingDate:int}")]
        public ActionResult<OutputDtoGetTraining> GetTrainingsByTrainingDateId(int idTrainingDate)
        {
            return Ok(_trainingService.GetByTrainingDateId(idTrainingDate));
        }
        
        [HttpGet]
        [Route("user/{idUser:int}")]
        public ActionResult<OutputDtoGetTraining> GetTrainingsByUserId(int idUser)
        {
            return Ok(_trainingService.GetByTrainingUserId(idUser));
        }

        [HttpPost]
        public ActionResult<OutputDtoAddTraining> Post([FromBody] InputDtoAddTraining inputDtoAddTraining)
        {
            return Ok(_trainingService.Create(inputDtoAddTraining));
        }
    }
}
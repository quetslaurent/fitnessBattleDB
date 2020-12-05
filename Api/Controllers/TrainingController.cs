using Application.Services.Training;
using Application.Services.Training.Dto;
using FitnessBattle.TokenManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/training")]
    [Authorize]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        private readonly ITokenManager _tokenManager;

        public TrainingController(ITrainingService trainingService,ITokenManager tokenManager)
        {
            _trainingService = trainingService;
            _tokenManager = tokenManager;
        }
        
        [HttpGet]
        [Route("date/{idTrainingDate:int}")]
        public ActionResult<OutputDtoGetTraining> GetTrainingsByTrainingDateId(int idTrainingDate)
        {
            return Ok(_trainingService.GetByTrainingDateId(idTrainingDate));
        }
        
        [HttpGet]
        [Route("user/{token}")]
        public ActionResult<OutputDtoGetTraining> GetTrainingsByUserId(string token)
        {
            return Ok(_trainingService.GetByTrainingUserId(_tokenManager.GetIdFromToken(token)));
        }

        [HttpPost]
        public ActionResult<OutputDtoAddTraining> Post([FromBody] InputDtoAddTraining inputDtoAddTraining)
        {
            return Ok(_trainingService.Create(inputDtoAddTraining));
        }
    }
}
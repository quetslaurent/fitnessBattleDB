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
        
        //renvoie les trainings correspondant à la date
        [HttpGet]
        [Route("date/{idTrainingDate:int}")]
        public ActionResult<OutputDtoGetTraining> GetTrainingsByTrainingDateId(int idTrainingDate)
        {
            return Ok(_trainingService.GetByTrainingDateId(idTrainingDate));
        }
        
        //renvoie les training de l'user via le token
        [HttpGet]
        [Route("user/{token}")]
        public ActionResult<OutputDtoGetTraining> GetTrainingsByUserId(string token)
        {
            return Ok(_trainingService.GetByTrainingUserId(_tokenManager.GetIdFromToken(token)));
        }
        
        //renvoie les training de l'user via l'id
        [HttpGet]
        [Route("user/{id:int}")]
        public ActionResult<OutputDtoGetTraining> GetTrainingsByUserId(int id)
        {
            return Ok(_trainingService.GetByTrainingUserId(id));
        }

        //permet de créer un training
        [HttpPost]
        public ActionResult<OutputDtoAddTraining> Post([FromBody] InputDtoAddTraining inputDtoAddTraining)
        {
            return Ok(_trainingService.Create(inputDtoAddTraining));
        }
        
        //permet de supprimer un training
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (_trainingService.DeleteTraining(id))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
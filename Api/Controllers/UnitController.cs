using Application.Services.Category;
using Application.Services.TrainingDate.Dto;
using Application.Services.Unit;
using Application.Services.Unit.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/units")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        public ActionResult<OutputDtoAddUnit> Query()
        {
            return Ok(_unitService.Query());
        }

        [HttpPost]
        public ActionResult<OutputDtoAddUnit> Post([FromBody] InputDtoAddUnit inputDtoAddUnit)
        {
            return Ok(_unitService.Create(inputDtoAddUnit));
        }
    }
}
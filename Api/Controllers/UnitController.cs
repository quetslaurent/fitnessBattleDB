using Application.Services.Unit;
using Application.Services.Unit.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/units")]
    [Authorize]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        //renvoie la liste des unités
        [HttpGet]
        public ActionResult<OutputDtoAddUnit> Query()
        {
            return Ok(_unitService.Query());
        }

        //permet de créer une nouvelle unité
        [HttpPost]
        public ActionResult<OutputDtoAddUnit> Post([FromBody] InputDtoAddUnit inputDtoAddUnit)
        {
            return Ok(_unitService.Create(inputDtoAddUnit));
        }
    }
}
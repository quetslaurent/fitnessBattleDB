using Application.Services.Category;
using Application.Services.Category.Dto;
using Application.Services.TrainingDate.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService unitService)
        {
            _categoryService = unitService;
        }

        [HttpGet]
        public ActionResult<OutputDtoQueryCategory> Query()
        {
            return Ok(_categoryService.Query());
        }

        [HttpGet]
        [Route("activities")]

        public ActionResult<OutputDtoQueryActivitiesByCategory> getActivitiesByCategory()
        {
            return Ok(_categoryService.getActivitiesByCategory());
        }

        [HttpPost]
        public ActionResult<OutputDtoAddCategory> Post([FromBody] InputDtoAddCategory inputDtoAddCategory)
        {
            return Ok(_categoryService.Create(inputDtoAddCategory));
        }
    }
}
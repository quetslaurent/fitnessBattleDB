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

        //renvoie la liste des catégories
        [HttpGet]
        public ActionResult<OutputDtoQueryCategory> Query()
        {
            return Ok(_categoryService.Query());
        }

        //renvoie une liste de catégorie avec pour chacune les activités correspondantes
        [HttpGet]
        [Route("activities")]

        public ActionResult<OutputDtoQueryActivitiesByCategory> getActivitiesByCategory()
        {
            return Ok(_categoryService.getActivitiesByCategory());
        }

        //permet de créer une categorie
        [HttpPost]
        public ActionResult<OutputDtoAddCategory> Post([FromBody] InputDtoAddCategory inputDtoAddCategory)
        {
            return Ok(_categoryService.Create(inputDtoAddCategory));
        }
    }
}
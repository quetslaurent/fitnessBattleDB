using System.Collections.Generic;
using Application.Services.Category.Dto;
using Application.Services.TrainingDate.Dto;

namespace Application.Services.Category
{
    public interface ICategoryService
    {
        IEnumerable<OutputDtoQueryCategory> Query();
        OutputDtoAddCategory Create(InputDtoAddCategory inputDtaAddCategory);
        IEnumerable<OutputDtoQueryActivitiesByCategory> getActivitiesByCategory();
    }
}
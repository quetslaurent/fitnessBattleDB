using System.Collections.Generic;
using Application.Services.Activity.Dto;

namespace Application.Services.Activity
{
    public interface IActivityService
    {
        IEnumerable<OutputDtoQueryActivity> GetByCategoryId(int categoryId);
        OutputDtoAddActivity Create(InputDtoAddActivity inputDtoAddActivity);

        bool Update(InputDtoAddActivity inputDtoAddActivity);

        bool DeleteActivity(int activityId);
    }
}
using System.Collections.Generic;
using Application.Services.Activity.Dto;

namespace Application.Services.Activity
{
    public interface IActivityService
    {
        IEnumerable<OutputDtoQueryActivity> GetByCategoryId(int categoryId);
        OutputDtoAddActivity Create(InputDtoAddActivity inputDtoAddActivity);

        bool Update(int id,InputDtoUpdateActivity inputDtoAddActivity);

        bool DeleteActivity(int activityId);
        IEnumerable<OutputDtoQueryActivity> query();
    }
}
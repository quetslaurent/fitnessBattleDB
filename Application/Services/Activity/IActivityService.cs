using System.Collections.Generic;
using Application.Services.Activity.Dto;

namespace Application.Services.Activity
{
    public interface IActivityService
    {
        IEnumerable<OutputDtoQueryActivity> Query();

        OutputDtoAddActivity Create(InputDtoAddActivity inputDtoAddActivity);
    }
}
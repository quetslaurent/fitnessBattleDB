using System.Collections.Generic;
using Application.Services.TrainingDate.Dto;

namespace Application.Services.TrainingDate
{
    public interface ITrainingDateService
    {
        IEnumerable<OutputDtoQueryTrainingDate> Query();

        OutputDtoAddTrainingDate Create(InputDtoAddTrainingDate inputDtoAddTrainingDate);
    }
}
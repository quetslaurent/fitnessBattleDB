using System.Collections.Generic;
using Application.Services.Training.Dto;
using Application.Services.TrainingDate.Dto;

namespace Application.Services.TrainingDate
{
    public interface ITrainingDateService
    {
        IEnumerable<OutputDtoQueryTrainingDate> Query();

        OutputDtoAddTrainingDate Create(InputDtoAddTrainingDate inputDtoAddTrainingDate);
    }
}
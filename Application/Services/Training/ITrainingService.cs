using System.Collections.Generic;
using Application.Services.Training.Dto;

namespace Application.Services.Training
{
    public interface ITrainingService
    {
        IEnumerable<OutputDtoGetTraining> GetByTrainingDateId(int dateId);
        
        IEnumerable<OutputDtoGetTraining> GetByTrainingUserId(int userId);
        
        OutputDtoAddTraining Create(InputDtoAddTraining inputDtoAddTraining);
        bool DeleteTraining(int id);
    }
}
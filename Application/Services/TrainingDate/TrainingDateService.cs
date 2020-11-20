
using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.TrainingDate.Dto;

namespace Application.Services.TrainingDate
{
    public class TrainingDateService : ITrainingDateService
    {
        private readonly ITrainingDateRepository _trainingDateRepository;

        public TrainingDateService(ITrainingDateRepository trainingDateRepository)
        {
            _trainingDateRepository = trainingDateRepository;
        }

        public IEnumerable<OutputDtoQueryTrainingDate> Query()
        {
            return _trainingDateRepository.Query().Select(trainingDate => new OutputDtoQueryTrainingDate
            {
                Id = trainingDate.Id,
                Date = trainingDate.Date
            });
        }
        
        public OutputDtoAddTrainingDate Create(InputDtoAddTrainingDate inputDtoAddTrainingDate)
        {
            var trainingDate = _trainingDateRepository.Create(inputDtoAddTrainingDate.Date);
            return new OutputDtoAddTrainingDate
            {
                Id=trainingDate.Id,
                Date = trainingDate.Date
            };
        }
        
        
    }
}
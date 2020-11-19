using System.Collections.Generic;
using Application.Repositories;
using Application.Services.Training.Dto;
using Domain.Training;

namespace Application.Services.Training
{
    public class TrainingService : ITrainingService
    {
        /*
        * On récupère les repositories qu'on a besoin
        */
        private readonly IActivityRepository _activityRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITrainingDateRepository _trainingDateRepository;
        private readonly ITrainingRepository _trainingRepository;
        
        //on recupère la Factory
        private readonly ITrainingFactory _trainingFactory = new TrainingFactory();

        //Constructeur
        public TrainingService(IActivityRepository activityRepository, IUserRepository userRepository, ITrainingDateRepository trainingDateRepository, ITrainingRepository trainingRepository)
        {
            _activityRepository = activityRepository;
            _userRepository = userRepository;
            _trainingDateRepository = trainingDateRepository;
            _trainingRepository = trainingRepository;
        }

        /*
         * Récupérer la liste des training ayant une même date
         */
        
        public IEnumerable<OutputDtoQueryTraining> GetByDateId(int dateId)
        {
            return _trainingRepository
                .GetByDateId(dateId)
                .Select(training => new OutputDtoQueryTraining
                {
                   Id = training.Id,
                   Repetitions = training.Repetitions,
                   ActivityName = training.Activity.Name,
                   TrainingDateValue = training.TrainingDate.Date
                   
                });
        }

        /**
         * Créer un training 
         */
        public OutputDtoAddTraining Create(InputDtoAddTraining inputDtoAddTraining)
        {
            var trainingFromDto = _trainingFactory.CreateTrainingFromValues()
            var trainingInDb = _trainingRepository.Create(trainingFromDto);
            
            return new OutputDtoAddTraining
            {
                Id=trainingInDb.Id,
                Repetitions = trainingInDb.Repetitions,
                ActivityName = trainingInDb.Activity.Name,
                TrainingDateValue = trainingInDb.TrainingDate.Date
            };
        }

        public bool DeleteTraining(int trainingId)
        {
            return _trainingRepository.Delete(trainingId);
        }
        
        
    }
}
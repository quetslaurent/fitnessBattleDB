using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Activity;
using Domain.TrainingDate;
using Domain.User;

namespace Domain.Training
{
    public class TrainingFactory : ITrainingFactory
    {
        public DateTime Date { get; set; }
        public IList<ITraining> Trainings { get; }

        public TrainingFactory()
        {
            Trainings = new List<ITraining>();
        }

        //créer une training depuis les valeurs passées en argument
        public ITraining CreateTrainingFromValues(double repetitions, IUser user, IActivity activity,
            ITrainingDate trainingDate)
        {
            return new Training
            {
                Repetitions = repetitions,
                User = user,
                Activity = activity,
                TrainingDate = trainingDate
            };
        }
        
        
    }
}
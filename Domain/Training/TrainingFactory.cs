using System;
using System.Collections.Generic;
using System.Linq;

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

        public ITraining CreateTrainingFromValues(string name, string password, string email, bool admin)
        {
            return new Training
            {
                
            };
        }
        
        
    }
}
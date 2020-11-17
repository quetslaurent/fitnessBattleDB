using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Training
{
    public class ActivityTrained : IActivityTrained
    {
        public DateTime Date { get; set; }
        public IList<ITraining> Trainings { get; }

        public ActivityTrained()
        {
            Trainings = new List<ITraining>();
        }

        public void AddActivity(ITraining training)
        {
            Trainings.Add(training);
        }

        public void AddActivities(IEnumerable<ITraining> trainings)
        {
            foreach (var training in trainings)
            {
               AddActivity(training);
            }
        }
        
    }
}
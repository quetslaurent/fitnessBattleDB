using System;
using System.Collections.Generic;

namespace Domain.Training
{
    public interface IActivityTrained
    {
        DateTime Date { get; set; }
        void AddActivity(ITraining training);
        void AddActivities(IEnumerable<ITraining> trainings);
        
    }
}
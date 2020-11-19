using System;
using System.Collections.Generic;

namespace Domain.Training
{
    public interface ITrainingFactory
    {
        DateTime Date { get; set; }

        ITraining CreateTrainingFromValues()
        
        
    }
}
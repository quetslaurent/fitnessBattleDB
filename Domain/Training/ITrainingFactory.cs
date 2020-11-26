using System;
using System.Collections.Generic;
using Domain.Activity;
using Domain.TrainingDate;
using Domain.User;

namespace Domain.Training
{
    public interface ITrainingFactory
    {
        DateTime Date { get; set; }

        ITraining CreateTrainingFromValues(double repetitions, IUser user, IActivity activity,
            ITrainingDate trainingDate, double points);


    }
}
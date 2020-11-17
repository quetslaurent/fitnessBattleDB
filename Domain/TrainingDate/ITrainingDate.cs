using System;
using Domain.Shared;

namespace Domain.TrainingDate
{
    public interface ITrainingDate : IEntity
    {
        DateTime Date { get; set; }
    }
}
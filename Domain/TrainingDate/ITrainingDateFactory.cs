using System;

namespace Domain.TrainingDate
{
    public interface ITrainingDateFactory
    {
        ITrainingDate Create(int id, DateTime dateTime);

        ITrainingDate CreateFromDateTime(DateTime dateTime);
    }
}
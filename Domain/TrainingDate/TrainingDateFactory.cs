using System;

namespace Domain.TrainingDate
{
    public class TrainingDateFactory : ITrainingDateFactory, IInstanceFromReaderFactory
    {
        public ITrainingDate Create(int id, DateTime dateTime)
        {
            return new TrainingDate
            {
                Id=id,
                Date=dateTime
            };
        }

        public ITrainingDate CreateFromDateTime(DateTime dateTime)
        {
            return Create(0, dateTime);
        }
    }
}
using System;

namespace Domain.TrainingDate
{
    public class TrainingDate : ITrainingDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public TrainingDate()
        {
            
        }
    }
}
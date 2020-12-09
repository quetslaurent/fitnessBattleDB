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

        public TrainingDate(int id, DateTime date)
        {
            Id = id;
            Date = date;
        }
        
        public TrainingDate(DateTime date)
        {
            Date = date;
        }

        protected bool Equals(TrainingDate other)
        {
            return Id == other.Id && Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TrainingDate) obj);
        }
    }
}
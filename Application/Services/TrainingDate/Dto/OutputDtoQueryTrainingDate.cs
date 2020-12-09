using System;

namespace Application.Services.TrainingDate.Dto
{
    public class OutputDtoQueryTrainingDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public OutputDtoQueryTrainingDate(DateTime date)
        {
            Date = date;
        }

        public OutputDtoQueryTrainingDate()
        {
        }

        protected bool Equals(OutputDtoQueryTrainingDate other)
        {
            return Id == other.Id && Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoQueryTrainingDate) obj);
        }
        
    }
}
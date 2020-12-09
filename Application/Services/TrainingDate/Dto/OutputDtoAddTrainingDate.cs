using System;

namespace Application.Services.TrainingDate.Dto
{
    public class OutputDtoAddTrainingDate
    {
        public int Id { get; set; } // le retour renvoie aussi l'id
        public DateTime Date { get; set; }

        public OutputDtoAddTrainingDate(DateTime date)
        {
            Date = date;
        }

        public OutputDtoAddTrainingDate()
        {
        }

        protected bool Equals(OutputDtoAddTrainingDate other)
        {
            return Id == other.Id && Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoAddTrainingDate) obj);
        }
        
    }
}
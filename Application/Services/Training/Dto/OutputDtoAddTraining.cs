using System;

namespace Application.Services.Training.Dto
{
    public class OutputDtoAddTraining
    {
        /*
     * DTO qui permets d’ajouter un nouveau Training,
     * cela permets de recevoir les éléments sans l’id pour créer un training,
     * car l’utilisateur ne doit pas entrer l’id dans les données.
     */
        public int Id { get; set; }
        public double Repetitions { get; set; }
        public string ActivityName { get; set; }
        public DateTime TrainingDateValue { get; set; }

        public OutputDtoAddTraining(int id, double repetitions, string activityName, DateTime trainingDateValue)
        {
            Id = id;
            Repetitions = repetitions;
            ActivityName = activityName;
            TrainingDateValue = trainingDateValue;
        }

        public OutputDtoAddTraining()
        {
        }

        protected bool Equals(OutputDtoAddTraining other)
        {
            return Repetitions.Equals(other.Repetitions) && ActivityName == other.ActivityName && TrainingDateValue.Equals(other.TrainingDateValue);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoAddTraining) obj);
        }
        
    }
}
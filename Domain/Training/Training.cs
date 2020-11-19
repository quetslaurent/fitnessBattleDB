using Domain.Activity;
using Domain.TrainingDate;
using Domain.User;

namespace Domain.Training
{
    public class Training : ITraining
    {
        public IUser User { get; set; }
        public double Repetitions { get; set; }
        public int Id { get; set; }
        public IActivity Activity { get; set; }
        public ITrainingDate TrainingDate { get; set; }

        public Training()
        {
            
        }
    }
}
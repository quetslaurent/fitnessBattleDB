using Domain.Activity;
using Domain.Shared;
using Domain.TrainingDate;
using Domain.User;

namespace Domain.Training
{
    public interface ITraining : IEntity
    {
        IUser User { get; set; }
        IActivity Activity { get; set; }
        
        double Repetitions { get; set; }
        
        ITrainingDate TrainingDate { get; set; }
    }
}
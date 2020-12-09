using System;
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
        
        public double Points { get; set; }

        public Training()
        {
            
        }

        public Training(IUser user, double repetitions, IActivity activity, ITrainingDate trainingDate)
        {
            User = user;
            Repetitions = repetitions;
            Activity = activity;
            TrainingDate = trainingDate;
        }

        protected bool Equals(Training other)
        {
            return Equals(User, other.User) && Repetitions.Equals(other.Repetitions) && Id == other.Id && Equals(Activity, other.Activity) && Equals(TrainingDate, other.TrainingDate) && Points.Equals(other.Points);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Training) obj);
        }
        
    }
}
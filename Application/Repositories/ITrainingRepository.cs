using System.Collections.Generic;
using Domain.Training;

namespace Application.Repositories
{
    public interface ITrainingRepository
    {
        IEnumerable<ITraining> Query();
        
        ITraining Create(ITraining training);

        bool Delete(int id);

        IEnumerable<ITraining> GetByDateId(int dateId);
        
        IEnumerable<ITraining> GetByUserId(int userId);
    }
}
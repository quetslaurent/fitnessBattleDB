using System.Collections.Generic;
using Domain.Training;

namespace Application.Repositories
{
    public interface ITrainingRepository
    {
        IEnumerable<ITraining> Query();

        ITraining GetById(int id);
        ITraining Create(ITraining training);
        bool Update(int id,ITraining training);
    }
}
using System;
using System.Collections.Generic;
using Domain.TrainingDate;

namespace Application.Repositories
{
    public interface ITrainingDateRepository
    {
        IEnumerable<ITrainingDate> Query();
        ITrainingDate GetById(int id);
        ITrainingDate Create(DateTime date);
    }
}
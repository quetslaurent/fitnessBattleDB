using System;
using System.Collections.Generic;

namespace Application.Repositories
{
    public interface ITrainingDateRepository
    {
        IEnumerable<ITrainingDate> Query();
        ITrainingDate GetById(int id);
        ITrainingDate Create(DateTime date);
    }
}
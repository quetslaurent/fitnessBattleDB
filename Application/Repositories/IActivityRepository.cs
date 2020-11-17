﻿using System.Collections.Generic;

namespace Application.Repositories
{
    public interface IActivityRepository
    {
        IEnumerable<IActivity> Query();
        IActivity GetById(int id);
        IActivity Create(IActivity activity);
        bool Update(int id, IActivity activity);
    }
}
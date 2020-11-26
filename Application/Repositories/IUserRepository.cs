﻿using System.Collections.Generic;
using Domain.User;

namespace Application.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<IUser> Query();
        IUser GetById(int id);
        IUser Create(IUser user);

        double GetPointsById(int id);
    }
}
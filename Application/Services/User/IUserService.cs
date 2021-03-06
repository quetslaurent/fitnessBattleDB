﻿using System.Collections.Generic;
using Application.Services.User.Dto;

namespace Application.Services.User
{
    public interface IUserService
    {
        IEnumerable<OutputDtoQueryUser> Query();
        OutputDtoAddUser Create(InputDtoAddUser inputDtaAddUser);
        double GetUserPointsById(int id);
        OutputDtoQueryUser GetUserById(int id);
        string HashPassword(string password);
        bool Update(int id, InputDtoUpdateUser inputDtoUpdateUser);
        bool DeleteUser(int id);
    }
}
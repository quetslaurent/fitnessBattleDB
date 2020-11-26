using System.Collections.Generic;
using Application.Services.User.Dto;

namespace Application.Services.User
{
    public interface IUserService
    {
        IEnumerable<OutputDtoQueryUser> Query();
        OutputDtoAddUser Create(InputDtoAddUser inputDtaAddUser);
        double GetUserPointsById(int id);
    }
}
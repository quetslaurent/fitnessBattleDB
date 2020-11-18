using System.Collections.Generic;
using Domain.User;

namespace Application.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<IUser> Query();
        IUser GetById(int id);
        IUser Create(IUser user);
        bool Update(int id, IUser user);
    }
}
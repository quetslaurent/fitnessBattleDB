using System.Collections.Generic;
using Domain.Activity;
using Domain.Category;
using Domain.Unit;

namespace Application.Repositories
{
    public interface IActivityRepository
    {
        IEnumerable<IActivity> Query();
        IActivity GetById(int id);
        IEnumerable<IActivity> GetByCategoryId(int categoryid);
        IActivity Create(IActivity activity);
        bool Update(int id, IActivity activity);

        bool Delete(int id);
    }
}
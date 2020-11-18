using System.Collections.Generic;
using Domain.Unit;

namespace Application.Repositories
{
    public interface IUnitRepository
    {
        IEnumerable<IUnit> Query();
        IUnit GetById(int id);
        IUnit Create(IUnit training);
        bool Update(int id,IUnit training);
    }
}
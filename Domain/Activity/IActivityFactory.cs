using Domain.Category;
using Domain.Unit;

namespace Domain.Activity
{
    public interface IActivityFactory
    {
        IActivity CreateFromValues(string name, double repetitions,IUnit unit,ICategory category );
    }
}
using Domain.Category;
using Domain.Unit;

namespace Domain.Activity
{
    public class ActivityFactory : IActivityFactory, IInstanceFromReaderFactory
    {
        public IActivity CreateFromValues(string name, double repetitions, IUnit unit, ICategory category)
        {
            return new Activity
            {
                Name = name,
                Repetitions = repetitions,
                Unit = unit,
                Category = category
            };
        }
    }
}
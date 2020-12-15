using Domain.Category;
using Domain.Unit;

namespace Domain.Activity
{
    public class ActivityFactory : IActivityFactory
    {
        //créer une activity depuis les valeurs passées en argument
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
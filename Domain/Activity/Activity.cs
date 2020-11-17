using Domain.Category;
using Domain.Unit;

namespace Domain.Activity
{
    public class Activity : IActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Repetitions { get; set; }
        public IUnit Unit { get; set; }
        public ICategory Category { get; set; }

        public Activity()
        {
            
        }
    }
}
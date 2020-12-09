using System;
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

        public Activity(int id, string name, double repetitions, IUnit unit, ICategory category)
        {
            Id = id;
            Name = name;
            Repetitions = repetitions;
            Unit = unit;
            Category = category;
        }

        protected bool Equals(Activity other)
        {
            return Id == other.Id && Name == other.Name && Repetitions.Equals(other.Repetitions) && Equals(Unit, other.Unit) && Equals(Category, other.Category);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Activity) obj);
        }
    }
}
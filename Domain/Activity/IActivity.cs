using Domain.Category;
using Domain.Shared;
using Domain.Unit;

namespace Domain.Activity
{
    public interface IActivity : IEntity
    {
        string Name { get; set; } //nom de l'activité
        double Repetitions { get; set; } //nombre de repetitions
       
        IUnit Unit { get; set; }
        ICategory Category { get; set; }
    }
}
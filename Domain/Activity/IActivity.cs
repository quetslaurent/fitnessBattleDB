using Domain.Shared;

namespace Domain.Activity
{
    public interface IActivity : IEntity
    {
        string Name { get; set; } //nom de l'activité
        double Repetitions { get; set; } //nombre de repetitions
       
        
    }
}
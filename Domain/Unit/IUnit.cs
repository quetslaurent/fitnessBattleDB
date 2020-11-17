using Domain.Shared;

namespace Domain.Unit
{
    public interface IUnit : IEntity
    {
        string Type { get; set; }
    }
}
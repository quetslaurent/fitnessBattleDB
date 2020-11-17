using Domain.Shared;

namespace Domain.Category
{
    public interface ICategory : IEntity
    {
        string Name { get; set; }
    }
}
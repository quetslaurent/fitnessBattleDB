namespace Domain.Category
{
    public interface ICategoryFactory
    {
        ICategory CreateFromName(string name);
    }
}
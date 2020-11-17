namespace Domain.Category
{
    public class CategoryFactory : ICategoryFactory
    {
        public ICategory CreateFromName(string name)
        {
            return new Category
            {
                Name = name
            };
        }
    }
}
namespace Domain.Category
{
    public class CategoryFactory : ICategoryFactory
    {
        //créer une categorie depuis les arguments
        public ICategory CreateFromName(string name)
        {
            return new Category
            {
                Name = name
            };
        }
    }
}
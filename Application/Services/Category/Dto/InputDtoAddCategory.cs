namespace Application.Services.Category.Dto
{
    /*
     * DTO qui permets d’ajouter une nouvelle Category,
     * cela permets de recevoir les éléments sans l’id pour créer une categorie,
     * car l’utilisateur ne doit pas entrer l’id dans les données.
     */
    public class InputDtoAddCategory
    {
        public string Name { get; set; }
        
    }
}
namespace Application.Services.Unit.Dto
{
    public class InputDtoAddUnit
    {
        /*
     * DTO qui permets d’ajouter un nouveau Unit,
     * cela permets de recevoir les éléments sans l’id pour créer un unit,
     * car l’utilisateur ne doit pas entrer l’id dans les données.
     */
        
        public string Type { get; set; }

        public InputDtoAddUnit(string type)
        {
            Type = type;
        }
        
    }
}
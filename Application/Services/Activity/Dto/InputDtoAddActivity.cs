using Domain.Category;
using Domain.Unit;

namespace Application.Services.Activity.Dto
{
    public class InputDtoAddActivity
    {
        /*
     * DTO qui permets d’ajouter une nouvelle Activity,
     * cela permets de recevoir les éléments sans l’id pour créer une activity,
     * car l’utilisateur ne doit pas entrer l’id dans les données.
     */

        public string Name { get; set; }
        public double Repetitions { get; set; }
        public IUnit Unit { get; set; }
        public ICategory Category { get; set; }
        
    }
}
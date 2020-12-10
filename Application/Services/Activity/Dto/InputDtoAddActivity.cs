
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
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        
        public InputDtoAddActivity()
        {
        }
        public InputDtoAddActivity(string name, double repetitions, int categoryId, int unitId)
        {
            Name = name;
            Repetitions = repetitions;
            CategoryId = categoryId;
            UnitId = unitId;
        }


    }
}
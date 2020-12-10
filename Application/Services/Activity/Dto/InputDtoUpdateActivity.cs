namespace Application.Services.Activity.Dto
{
    public class InputDtoUpdateActivity
    {
        public string Name { get; }
        public double Repetitions { get;}
        public int CategoryId { get; }
        public int UnitId { get;}

        public InputDtoUpdateActivity()
        {
        }
        public InputDtoUpdateActivity(string name, double repetitions, int categoryId, int unitId)
        {
            Name = name;
            Repetitions = repetitions;
            CategoryId = categoryId;
            UnitId = unitId;
        }
    }
}
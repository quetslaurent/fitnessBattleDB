namespace Application.Services.Activity.Dto
{
    public class OutputDtoQueryActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Repetitions { get; set; }

        public string CategoryName { get; set; }
        public string UnitType { get; set; }

        public OutputDtoQueryActivity()
        {
        }

        public OutputDtoQueryActivity(string name, double repetitions, string categoryName, string unitType)
        {
            Name = name;
            Repetitions = repetitions;
            CategoryName = categoryName;
            UnitType = unitType;
        }

        protected bool Equals(OutputDtoQueryActivity other)
        {
            return Id == other.Id && Name == other.Name && Repetitions.Equals(other.Repetitions) && CategoryName == other.CategoryName && UnitType == other.UnitType;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoQueryActivity) obj);
        }
    }
}
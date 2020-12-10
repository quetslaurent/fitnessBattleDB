namespace Application.Services.Activity.Dto
{
    public class OutputDtoAddActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Repetitions { get; set; }
        public string CategoryName { get; set; }
        public string UnitType { get; set; }

        public OutputDtoAddActivity()
        {
        }
        public OutputDtoAddActivity(int id, string name, double repetitions, string categoryName, string unitType)
        {
            Id = id;
            Name = name;
            Repetitions = repetitions;
            CategoryName = categoryName;
            UnitType = unitType;
        }

        protected bool Equals(OutputDtoAddActivity other)
        {
            return Id == other.Id && Name == other.Name && Repetitions.Equals(other.Repetitions) && CategoryName == other.CategoryName && UnitType == other.UnitType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoAddActivity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Repetitions.GetHashCode();
                hashCode = (hashCode * 397) ^ (CategoryName != null ? CategoryName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (UnitType != null ? UnitType.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
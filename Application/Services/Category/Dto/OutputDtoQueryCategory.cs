namespace Application.Services.Category.Dto
{
    public class OutputDtoQueryCategory
    {
        public int Id { get; set; } // le retour renvoie aussi l'id
        public string Name { get; set; }

        public OutputDtoQueryCategory()
        {
        }

        public OutputDtoQueryCategory(string name)
        {
            Name = name;
        }

        protected bool Equals(OutputDtoQueryCategory other)
        {
            return Id == other.Id && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoQueryCategory) obj);
        }
    }
}
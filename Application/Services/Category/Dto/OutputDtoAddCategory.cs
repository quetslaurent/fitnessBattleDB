namespace Application.Services.Category.Dto
{
    public class OutputDtoAddCategory
    {
        public int Id { get; set; } // le retour renvoie aussi l'id
        public string Name { get; set; }

        public OutputDtoAddCategory()
        {
        }

        public OutputDtoAddCategory(string name)
        {
            Name = name;
        }

        protected bool Equals(OutputDtoAddCategory other)
        {
            return Id == other.Id && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoAddCategory) obj);
        }
    }
}
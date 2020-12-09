namespace Application.Services.Unit.Dto
{
    public class OutputDtoQueryUnit
    {
        public int Id { get; set; } // le retour renvoie aussi l'id
        public string Type { get; set; }
        public OutputDtoQueryUnit()
        {
        }
        public OutputDtoQueryUnit(string type)
        {
            Type = type;
        }

        protected bool Equals(OutputDtoQueryUnit other)
        {
            return Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoQueryUnit) obj);
        }
        
    }
}
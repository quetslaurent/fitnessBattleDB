

namespace Application.Services.Unit.Dto
{
    public class OutputDtoAddUnit
    {
        public int Id { get; set; } // le retour renvoie aussi l'id
        public string Type { get; set; }


        public OutputDtoAddUnit(string type)
        {
            Type = type;
        }

        public OutputDtoAddUnit()
        {
        }

        protected bool Equals(OutputDtoAddUnit other)
        {
            return Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoAddUnit) obj);
        }
        
    }
}
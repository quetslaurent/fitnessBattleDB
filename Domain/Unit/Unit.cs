
namespace Domain.Unit
{
    public class Unit : IUnit
    {
        public int Id { get; set; }
        public string Type { get; set; }
        
        public Unit( )
        {
        }
        public Unit(string type)
        {
            Type = type;
        }

        protected bool Equals(Unit other)
        {
            return Id == other.Id && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Unit) obj);
        }
        
    }
}
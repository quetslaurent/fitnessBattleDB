
namespace Domain.Unit
{
    public class UnitFactory : IUnitFactory
    {
        //crée une unité depuis un type
        public IUnit CreateFromType(string type)
        {
            return new Unit
            {
                Type = type
            };
        }
    }
}
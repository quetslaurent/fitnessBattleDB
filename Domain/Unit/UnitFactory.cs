using Domain.User;

namespace Domain.Unit
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateFromType(string type)
        {
            return new Unit
            {
                Type = type
            };
        }
    }
}
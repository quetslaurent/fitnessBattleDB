namespace Domain.Unit
{
    public interface IUnitFactory
    {
        IUnit CreateFromType(string type);
    }
}
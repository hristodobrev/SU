namespace Empires.Buildings.Interfaces
{
    using Empires.Units;
    using Empires.Resources;

    public interface IBuilding
    {
        Unit ProduceUnit();

        Resource ProduceResource();
    }
}

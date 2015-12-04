namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System.Linq;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            IStarship ship = this.GameEngine.Starships.FirstOrDefault(s => s.Name.Equals(shipName));

            System.Console.WriteLine(ship.ToString());
        }
    }
}

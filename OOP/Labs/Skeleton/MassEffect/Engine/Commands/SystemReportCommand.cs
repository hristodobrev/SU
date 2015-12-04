namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string locationName = commandArgs[1];

            IEnumerable<IStarship> intactShips = this.GameEngine.Starships
                .Where(s => s.Health > 0)
                .OrderBy(s => s.Health)
                .ThenBy(s => s.Shields);

            StringBuilder output = new StringBuilder();
            output.AppendLine("Intact ships:");
            output.AppendLine(intactShips.Any() ? string.Join("\n", intactShips) : "N/A");

            IEnumerable<IStarship> destroyedShips = this.GameEngine.Starships
                .Where(s => s.Health <= 0)
                .OrderBy(s => s.Name);

            output.AppendLine("Destroyed ships:");
            output.AppendLine(destroyedShips.Any() ? string.Join("\n", destroyedShips) : "N/A");

            Console.WriteLine(output.ToString());
        }
    }
}

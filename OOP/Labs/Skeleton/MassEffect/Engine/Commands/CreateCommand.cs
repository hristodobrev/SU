namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using GameObjects.Enhancements;
    using GameObjects.Ships;
    using System.Linq;
    using System;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string shipName = commandArgs[2];
            string locationName = commandArgs[3];

            bool shipAlreadyExists = this.GameEngine.Starships.Any(s => s.Name == shipName);

            if (shipAlreadyExists)
            {
                return;
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationName);
            StarshipType shipType = (StarshipType)Enum.Parse(typeof(StarshipType), type);

            IStarship ship = this.GameEngine.ShipFactory.CreateShip(shipType, shipName, location);
            this.GameEngine.Starships.Add(ship);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enhancmentType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i]);

                Enhancement enhancement = this.GameEngine.EnhancementFactory.Create(enhancmentType);
                ship.AddEnhancement(enhancement);
            }

            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}

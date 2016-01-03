namespace Empires.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Empires.Buildings;
    using Empires.UI.Interfaces;
    using Empires.Units;
    using Empires.Resources;
    using Empires.Enums;

    public class Engine
    {
        private List<Building> buildings = new List<Building>();
        private List<Unit> units = new List<Unit>();
        private Resource gold;
        private Resource steel;
        private IReader reader;
        private IWritter writter;

        public Engine(IReader reader, IWritter writter)
        {
            this.gold = new Resource(ResourceType.Gold);
            this.steel = new Resource(ResourceType.Steel);
            this.Reader = reader;
            this.Writter = writter;
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Reader cannot be null");
                }
                this.reader = value;
            }
        }

        public IWritter Writter
        {
            get
            {
                return this.writter;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Reader cannot be null");
                }
                this.writter = value;
            }
        }

        public void Run()
        {
            string command = this.Reader.Read();
            while (!command.Equals("armistice"))
            {
                this.ExecuteCommand(command);

                command = this.Reader.Read();
            }
        }

        private void ExecuteCommand(string command)
        {
            string[] commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            bool invalidCommand = false;

            switch (commandArgs[0])
            {
                case "build":
                    this.Build(commandArgs[1]);
                    break;
                case "skip":
                    
                    break;
                case "empire-status":
                    this.PrintStatus();
                    break;
                default:
                    this.Writter.Write("Command is invalid.");
                    invalidCommand = true;
                    break;
            }

            if (!invalidCommand)
            {
                this.MakeTurn();
            }
        }

        private void MakeTurn()
        {
            foreach (var building in this.buildings)
            {
                building.Turns++;

                if (building.TryProduceResource())
                {
                    Resource resource = building.ProduceResource();
                    if (resource.ResourceType.Equals(ResourceType.Gold))
                    {
                        this.gold.Quantity += resource.Quantity;
                    }
                    else if (resource.ResourceType.Equals(ResourceType.Steel))
                    {
                        this.steel.Quantity += resource.Quantity;
                    }
                    else
                    {
                        //is invalid throw exception
                    }
                }

                if (building.TryProduceUnit())
                {
                    this.units.Add(building.ProduceUnit());
                }

            }
        }

        private void PrintStatus() 
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Treasury:");
            output.AppendLine("--Gold: " + this.gold.Quantity);
            output.AppendLine("--Steel: " + this.steel.Quantity);
            output.AppendLine("Buildings:");

            if (this.buildings.Count == 0)
            {
                output.AppendLine("N/A");
            }
            else
            {
                foreach (var building in this.buildings)
                {
                    output.AppendLine(building.ToString());
                }
            }

            output.AppendLine("Units:");

            if (this.units.Count == 0)
            {
                output.Append("N/A");
            }
            else
            {
                var archers = this.units.FindAll(a => a is Archer);
                var swordsmen = this.units.FindAll(a => a is Swordsman);
                string archersString = null;
                string swordsmenString = null;
                if (archers.Count != 0)
                {
                    archersString = "--Archer: " + archers.Count;
                }
                if (swordsmen.Count != 0)
                {
                    swordsmenString = "--Swordsman: " + swordsmen.Count;
                }
                if (this.units[0] is Archer)
                {
                    if (archersString != null)
                    {
                        output.AppendLine(archersString);
                    }
                    if (swordsmenString != null)
                    {
                        output.Append(swordsmenString);
                    }
                }
                else
                {
                    if (swordsmenString != null)
                    {
                        output.AppendLine(swordsmenString);
                    }
                    if (archersString != null)
                    {
                        output.Append(archersString);
                    }
                }
            }

            this.Writter.Write(output.ToString());
        }

        private void Build(string building)
        {
            switch (building.ToLower())
            {
                case "archery":
                    this.buildings.Add(new Archery());
                    break;
                case "barracks":
                    this.buildings.Add(new Barracks());
                    break;
                default:
                    writter.Write("Building does not exist.");
                    break;
            }
        }
    }
}

namespace Military.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Data;

    using Exceptions;

    using Interfaces;

    using Models.Battle_Units;
    using Models.Eqiupments;
    using Models.Eqiupments.Repairing_Kits;
    using Models.Equipments.Shileds;
    using Models.Equipments.Weapons;
    using Models.Fighting_Utilities;
    using Models.Places;
    using Models.Weapons;

    public class Engine
    {
        private IDatabase database;

        public Engine(IReader reader, IWriter writer)
        {
            this.database = new Database();
            this.Reader = reader;
            this.Writer = writer;
        }

        private IReader Reader { get; set; }

        private IWriter Writer { get; set; }

        public void Run()
        {
            string command = this.Reader.ReadLine();
            while (!command.Equals("End"))
            {
                string message = null;
                try
                {
                    message = this.ExecuteCommand(command);
                }
                catch (InvalidCommandException ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
                catch (NotExistingElementException ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
                catch (AlreadyExistingElementException ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
                catch (InconsistentEquipmentException ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine("Something went realy wrong...");
                    this.Writer.WriteLine(ex.Message);
                }
                
                this.Writer.WriteLine(message);

                command = this.Reader.ReadLine();
            }
        }

        private string ExecuteCommand(string command)
        {
            string[] commandArgs = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (commandArgs.Length == 0)
            {
                throw new InvalidCommandException("Empty line, how exciting...");
            }

            string action = commandArgs[0];
            string message;
            switch (action)
            {
                case "Establish":
                    message = this.EstablishCommand(commandArgs);
                    break;
                case "Create":
                    message = this.CreateCommand(commandArgs);
                    break;
                case "Equip":
                    message = this.EquipCommand(commandArgs);
                    break;
                case "Attack":
                    message = this.AttackCommand(commandArgs);
                    break;
                case "Info":
                    message = this.InfoCommand(commandArgs);
                    break;
                default:
                    message = "Invalid Command";
                    break;
            }

            return message;
        }

        private string EstablishCommand(string[] commandArgs)
        {
            if (commandArgs.Length != 4)
            {
                throw new InvalidCommandException("This command should define name, capacity and type of the place.");
            }

            string name = commandArgs[1];
            int capacity = int.Parse(commandArgs[2]);
            PlaceType placeType = (PlaceType) Enum.Parse(typeof (PlaceType), commandArgs[3]);

            if (this.database.GetPlaceByName(name) != null)
            {
                throw new AlreadyExistingElementException("Already exists place with this name.");
            }

            Place place = new Place(name, capacity, placeType);

            this.database.AddPlace(place);
            string message = string.Format("Successfuly created place {0} of type {1} with size of {2}.", name, placeType, capacity);

            return message;
        }

        private string CreateCommand(string[] commandArgs)
        {
            if (commandArgs.Length == 1)
            {
                throw new InvalidCommandException("This command should contain the parameters of the type you want to create.");
            }

            // Learn to use Reflection!
            string message;
            if (commandArgs[1].Equals("Aircraft"))
            {
                if (commandArgs.Length != 4)
                {
                    throw new InvalidCommandException("This command should define name and health of the unit.");
                }

                string name = commandArgs[2];
                int health = int.Parse(commandArgs[3]);

                if (this.database.GetBattleUnitByName(name) != null)
                {
                    throw new AlreadyExistingElementException("Already exists aircraft with this name.");
                }

                Aircraft aircraft = new Aircraft(name, health);
                this.database.AddBattleUnit(aircraft);
                message = String.Format("Successful created ship {0}: {1} Health", name, health);
            }
            else if (commandArgs[1].Equals("Weapon"))
            {
                if (commandArgs.Length < 4 || commandArgs.Length > 5)
                {
                    throw new InvalidCommandException("This command should define name, damage and carrier(optional) of the weapon.");
                }

                string name = commandArgs[2];
                int damage = int.Parse(commandArgs[3]);

                if (this.database.GetEquipmentByName(name) != null)
                {
                    throw new AlreadyExistingElementException("Already exists equipment with this name.");
                }

                Weapon weapon = new Weapon(name, damage, null);

                if (commandArgs.Length == 5)
                {
                    string unitName = commandArgs[4];
                    var carrier = this.database.GetBattleUnitByName(unitName);
                    if (carrier == null)
                    {
                        throw new NotExistingElementException(string.Format("There is no unit with name {0}", unitName));
                    }
                    weapon.Carrier = carrier;
                }

                this.database.AddEquipment(weapon);
                message = String.Format("Successful created weapon {0}: {1} Damage", name, damage);
            }
            else if (commandArgs[1].Equals("Shield"))
            {
                if (commandArgs.Length < 4 || commandArgs.Length > 5)
                {
                    throw new InvalidCommandException("This command should define name, armor and carrier(optional) of the shield.");
                }

                string name = commandArgs[2];
                int armor = int.Parse(commandArgs[3]);

                if (this.database.GetEquipmentByName(name) != null)
                {
                    throw new AlreadyExistingElementException("Already exists equipment with this name.");
                }

                Shield shield = new Shield(name, armor, null);
                this.database.AddEquipment(shield);
                message = String.Format("Successful created shield {0}: {1} Armor", name, armor);
            }
            else if (commandArgs[1].Equals("RepairingKit"))
            {
                if (commandArgs.Length < 4 || commandArgs.Length > 5)
                {
                    throw new InvalidCommandException("This command should define name, healing points and carrier(optional) of the reapairing kit.");
                }

                string name = commandArgs[2];
                int healingPoints = int.Parse(commandArgs[3]);

                if (this.database.GetEquipmentByName(name) != null)
                {
                    throw new AlreadyExistingElementException("Already exists equipment with this name.");
                }

                RepairingKit repairingKit = new RepairingKit(name, healingPoints, null);
                this.database.AddEquipment(repairingKit);
                message = String.Format("Successful created repairing kit {0}: {1} Healing Points", name, healingPoints);
            }
            else
            {
                throw new InvalidCommandException(string.Format("Cannot create \"{0}\"", string.Join(" ", commandArgs.Skip(1))));
            }

            return message;
        }

        private string EquipCommand(string[] commandArgs)
        {
            if (commandArgs.Length != 3)
            {
                throw new InvalidCommandException("This command should indicate the name of the carrier and the name of the equipment.");
            }

            string unitName = commandArgs[1];
            string equipmentName = commandArgs[2];

            IBattleUnit unit = this.database.GetBattleUnitByName(unitName);
            Equipment equipment = this.database.GetEquipmentByName(equipmentName);

            if (unit == null)
            {
                throw new NotExistingElementException(String.Format("There is no unit with name {0}.", unitName));
            }
            if (equipment == null)
            {
                throw new NotExistingElementException(String.Format("There is no equipment with name {0}.", equipmentName));
            }

            unit.Equip(equipment);
            return String.Format("Unit {0} successfuly equiped {1}", unitName, equipmentName);
        }

        private string AttackCommand(string[] commandArgs)
        {
            if (commandArgs.Length != 3)
            {
                throw new InvalidCommandException("This command should define the name of the attacker and of the defender.");
            }

            string attackerName = commandArgs[1];
            string defenderName = commandArgs[2];

            IBattleUnit attacker = this.database.GetBattleUnitByName(attackerName);
            IBattleUnit defender = this.database.GetBattleUnitByName(defenderName);

            if (attacker == null)
            {
                throw new NotExistingElementException(string.Format("There is no unit with name {0}", attackerName));
            }
            if (defender == null)
            {
                throw new NotExistingElementException(string.Format("There is no unit with name {0}", attackerName));
            }
            if(!(attacker is IFightingUnit))
            {
                throw new ArgumentException("The attacking unit cannot attack, ");
            }

            FightInfo info = ((IFightingUnit) attacker).Attack(defender);



            throw new NotImplementedException();
        }

        private string InfoCommand(string[] commandArgs)
        {
            string message;
            if (commandArgs.Length == 1)
            {
                // Hole information
                StringBuilder info = new StringBuilder();

            }
            else if (commandArgs.Length == 2)
            {
                var element = this.database.GetElementByName(commandArgs[1]);
                message = element.ToString();
            }
            else
            {
                throw new InvalidCommandException("This command should contain name of the unit, place or equipment or should be called alone.");
            }

            return message;
        }
    }
}

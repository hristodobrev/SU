namespace Military.Core
{
    using System;

    using Interfaces;

    using Models.Battle_Units;

    public class CommandExecutor : ICommandExecutor
    {
        public string ExecuteCommand(string command)
        {
            string[] commandArgs = command.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            string action = commandArgs[0];
            string message = null;
            switch (action)
            {
                case "create":
                    message = this.CreateCommand(commandArgs);
                    break;
                case "equip":
                    message = this.EquipCommand(commandArgs);
                    break;
                case "attack":
                    message = this.AttackCommand(commandArgs);
                    break;
                case "info":
                    message = this.InfoCommand(commandArgs);
                    break;
            }

            return message;
        }

        private string CreateCommand(string[] commandArgs)
        {
            // Learn to use Reflection!
            if (commandArgs[1].Equals("BattleUnit"))
            {
                Aircraft aircraft = new Aircraft(commandArgs[2], int.Parse(commandArgs[3]));
            }

            throw new NotImplementedException();
        }

        private string EquipCommand(string[] commandArgs)
        {
            throw new NotImplementedException();
        }

        private string AttackCommand(string[] commandArgs)
        {
            throw new NotImplementedException();
        }

        private string InfoCommand(string[] commandArgs)
        {
            throw new NotImplementedException();
        }
        
    }
}

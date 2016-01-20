namespace December_2015_Exam.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using December_2015_Exam.Interfaces;
    using December_2015_Exam.Models.Blobs;
    using December_2015_Exam.Models.AttackTypes;
    using December_2015_Exam.Models.BehaviorTypes;

    public class Engine : IEngine
    {
        private List<IBlob> blobs;

        public Engine(IReader reader, IWritter writter)
        {
            this.Writter = writter;
            this.Reader = reader;
            this.blobs = new List<IBlob>();
        }

        private IReader Reader { get; set; }

        private IWritter Writter { get; set; }

        public void Run()
        {
            string command = Reader.ReadLine();

            if (command.Equals("report-events"))
            {
                Constants.Constants.useEvents = true;
            }

            while (!command.Equals("drop"))
            {
                string[] inputArgs = command.Split();

                bool hadAttack = false;

                switch (inputArgs[0])
                {
                    case "create":
                        this.CreateCommand(inputArgs);
                        break;
                    case "attack":
                        this.AttackCommand(inputArgs);
                        hadAttack = true;
                        break;
                    case "pass":

                        break;
                    case "status":
                        this.StatusCommand(inputArgs);
                        break;
                    default:
                        break;
                }

                if (!hadAttack)
                {
                    foreach (var blob in this.blobs)
                    {
                        blob.Update();
                    }
                }

                command = Reader.ReadLine();
            }
        }

        private void CreateCommand(string[] inputArgs)
        {
            string name = inputArgs[1];
            int health = int.Parse(inputArgs[2]);
            int damage = int.Parse(inputArgs[3]);
            Behavior behavior = null;
            IAttack attack = null;

            switch (inputArgs[4])
            {
                case "Inflated":
                    behavior = new InflatedBehavior();
                    break;
                case "Aggressive":
                    behavior = new AggressiveBehavior();
                    break;
                default:
                    break;
            }

            switch (inputArgs[5])
            {
                case "PutridFart":
                    attack = new PutridFart();
                    break;
                case "Blobplode":
                    attack = new BlobPlode();
                    break;
                default:
                    break;
            }

            var blob = new Blob(name, health, damage, behavior, attack);
            if (Constants.Constants.useEvents)
            {
                blob.BehaviorType.HasTriggered += BehaviorType_HasTriggered;
                blob.HasDied += blob_HasDied;
            }

            this.blobs.Add(blob);
        }

        private void blob_HasDied(IBlob parent)
        {
            Writter.WriteLine("Blob {0} was killed", parent.Name);
        }

        private void BehaviorType_HasTriggered(IBlob parent)
        {
            Writter.WriteLine("Blob {0} toggled {1}", parent.Name, parent.BehaviorType.GetType().Name);
        }

        private void StatusCommand(string[] inputArgs)
        {
            foreach (var blob in this.blobs)
            {
                Writter.Write(blob.ToString());
            }
        }

        private void AttackCommand(string[] inputArgs)
        {
            string attackerName = inputArgs[1];
            string targetName = inputArgs[2];

            var attacker = this.blobs.
                FirstOrDefault(b => b.Name.Equals(attackerName));
            var target = this.blobs.
                FirstOrDefault(t => t.Name.Equals(targetName));

            if (attacker == null || target == null)
            {
                throw new ArgumentNullException("Blob does not exist.");
            }

            attacker.Attack(target);
            if (attacker.BehaviorType.GetType().Name.Equals("InflatedBehavior"))
            {
                attacker.Update();
            }
        }
    }
}

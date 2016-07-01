namespace Military.Models.Eqiupments
{
    using System;

    using Interfaces;

    public abstract class Equipment
    {
        private string name;

        protected Equipment(string name, IBattleUnit carrier)
        {
            this.Name = name;
            this.Carrier = carrier;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IBattleUnit Carrier { get; set; }
    }
}

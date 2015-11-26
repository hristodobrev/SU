using System;

namespace _02.Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} [{1} {2}] said: FRUAUGH.", this.Name, this.Gender, this.GetType().Name);
        }
    }
}

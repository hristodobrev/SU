using System;

namespace _02.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} [{1} {2}] said: Miauu.", this.Name, this.Gender, this.GetType().Name);
        }
    }
}

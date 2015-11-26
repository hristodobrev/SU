using System;

namespace _02.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} [{1} {2}] barked: UOAUGH.", this.Name, this.Gender, this.GetType().Name);
        }
    }
}

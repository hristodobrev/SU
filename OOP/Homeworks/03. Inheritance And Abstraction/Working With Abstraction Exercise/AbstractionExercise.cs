using System;

namespace Working_With_Abstraction_Exercise
{
    using Characters;

    class AbstractionExercise
    {
        static void Main()
        {
            Character mage = new Mage(); // The punisher
            Character warrior = new Warrior();
            Priest priest = new Priest();

            PrintInfo(mage, warrior, priest);
            Console.WriteLine("Mage attacks the Warrior; Priest heals the Mage.");

            mage.Attack(warrior);
            priest.Heal(mage);
            PrintInfo(mage, warrior, priest);
            Console.WriteLine("Warrior attacks the Mage");

            warrior.Attack(mage);
            PrintInfo(mage, warrior, priest);
            Console.WriteLine("Priest heals the Warrior (he betrays the Mage).");

            priest.Heal(warrior);
            PrintInfo(mage, warrior, priest);
            Console.WriteLine("Mage attacks the Warrior; Priest heals the Warrior.");

            mage.Attack(warrior);
            priest.Heal(warrior);
            PrintInfo(mage, warrior, priest);
            Console.WriteLine("Mage attacks the Warrior; Warrior attacks the Mage.");

            mage.Attack(warrior);
            warrior.Attack(mage);
            PrintInfo(mage, warrior, priest);
            Console.WriteLine("Mage punishes the Warrior and the Priest by one-shoting them.");

            mage.Attack(warrior);
            mage.Attack(priest);
            PrintInfo(mage, warrior, priest);
        }

        private static void PrintInfo(Character mage, Character warrior, Character priest)
        {
            Console.WriteLine("{0}: {1}", mage.GetType().Name, mage.Health);
            Console.WriteLine("{0}: {1}", warrior.GetType().Name, warrior.Health);
            Console.WriteLine("{0}: {1}", priest.GetType().Name, priest.Health);
        }
    }
}

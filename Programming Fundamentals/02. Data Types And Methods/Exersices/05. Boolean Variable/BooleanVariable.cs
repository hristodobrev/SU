namespace _05.Boolean_Variable
{
    using System;

    class BooleanVariable
    {
        static void Main()
        {
            string boolean = Console.ReadLine();

            Console.WriteLine(Convert.ToBoolean(boolean) ? "Yes" : "No");
        }
    }
}

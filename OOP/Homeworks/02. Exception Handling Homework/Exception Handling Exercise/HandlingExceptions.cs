using System;

namespace Exception_Handling_Exercise
{
    class HandlingExceptions
    {
        static void Main()
        {
            try
            {
                Person pesho = new Person("Gosho", "Goshev", 121);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
        }
    }
}

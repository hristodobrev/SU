using System;

class SquareRoot
{
    static void Main()
    {
        try
        {
            uint number = uint.Parse(Console.ReadLine());
            Console.WriteLine("+-" + Math.Sqrt(number));
        }
        catch (FormatException)
        {
            Console.WriteLine("invalid number");
        }
        catch (OverflowException)
        {
            Console.WriteLine("invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}
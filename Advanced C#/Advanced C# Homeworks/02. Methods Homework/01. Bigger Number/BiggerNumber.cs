using System;
class BiggerNumber
{
    static void Main()
    {
        // Input
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        // Output
        Console.WriteLine(GetMax(firstNumber, secondNumber));
    }

    // Logic

    static int GetMax(int first, int second)
    {
        if (first < second)
        {
            return second;
        }
        return first;
    }
}
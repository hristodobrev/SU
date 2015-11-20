using System;

class EnterNumbers
{
    static void Main()
    {
        ReadNumber(5, 100);
        ReadNumber();
    }

    private static void ReadNumber()
    {
        int maxNumber = 1;
        for (int i = 0; i < 10; i++)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number >= 100 || number <= maxNumber)
                {
                    throw new FormatException();
                }
                maxNumber = number;
            }
            catch(FormatException)
            {
                Console.WriteLine(
                    "Please enter valid number greater than {0} and smaller than 100",
                    maxNumber);
                i--;
                continue;
            }
        }
    }

    private static void ReadNumber(int start, int end)
    {
        try
        {
            int number = int.Parse(Console.ReadLine());
            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException(String.Format(
                    "Number should be in range [{0} ... {1}].",
                    start,
                    end));
            }
        }
        catch(FormatException)
        {
            throw new FormatException("Number should contain only digits.");
        }  
    }
}
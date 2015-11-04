using System;

class LetterChangeNumbers
{
    static void Main()
    {
        // Input
        string[] strings = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

        // Output
        Console.WriteLine("{0:F2}", CalculateSum(strings));
    }
    // Logic
    static double CalculateSum(string[] text)
    {
        double sum = 0;

        for (int i = 0; i < text.Length; i++)
        {
            char firstChar = text[i][0];
            char lastChar = text[i][text[i].Length - 1];
            string stringNumber = text[i].Remove(0, 1);
            double number = double.Parse(stringNumber.Remove(stringNumber.Length - 1));
            if (char.IsUpper(firstChar))
            {
                number /= (firstChar - 64);
            }
            else
            {
                number *= (firstChar - 96);
            }
            if (char.IsUpper(lastChar))
            {
                number -= (lastChar - 64);
            }
            else
            {
                number += (lastChar - 96);
            }
            sum += number;
        }

        return sum;
    }

}
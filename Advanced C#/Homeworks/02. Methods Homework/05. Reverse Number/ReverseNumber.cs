using System;
class ReverseNumber
{
    static void Main()
    {
        // Input
        float number = float.Parse(Console.ReadLine());

        // Ouput
        Console.WriteLine(GetReversedNumber(number));
    }

    // Logic

    static float GetReversedNumber(float number)
    {
        char[] charNumber = number.ToString().ToCharArray();
        char[] reversedCharNumber = new char[charNumber.Length];
        for (int i = 0; i < charNumber.Length; i++)
        {
            reversedCharNumber[i] = charNumber[(charNumber.Length - 1) - i];
        }
        return float.Parse(string.Join("", reversedCharNumber));
    }

}
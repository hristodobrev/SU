using System;
class LastDigitOfNumber
{
    static void Main()
    {
        // Input
        int number = int.Parse(Console.ReadLine());
        
        // Output
        Console.WriteLine(LastDigitAsWord(number));
    }

    // Logic

    static string LastDigitAsWord(int number)
    {
        number %= 10;
        switch (number)
        {
            case 1:
                return "one";
                break;
            case 2:
                return "two";
                break;
            case 3:
                return "three";
                break;
            case 4:
                return "four";
                break;
            case 5:
                return "five";
                break;
            case 6:
                return "six";
                break;
            case 7:
                return "seven";
                break;
            case 8:
                return "eight";
                break;
            case 9:
                return "nine";
                break;
            default:
                return "Not valid input";
                break;
        }
    }
}
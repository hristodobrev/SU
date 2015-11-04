using System;
class LetterCreator
{
    static void Main()
    {
        // Input
        string sender = Console.ReadLine();
        string receiver = Console.ReadLine();
        DateTime currentTime = DateTime.Now;
        
        // Output
        PrintLetter(sender, receiver, currentTime);
    }

    // Logic

    static void PrintLetter(string sender, string receiver, DateTime currentTime)
    {
        Console.WriteLine("Dear {0},", receiver);
        Console.WriteLine("I hope I find you in good health.\nI need to inform you that the cheese has run away.\nSincerely, {0}", sender);
        Console.WriteLine(currentTime);
    }

}
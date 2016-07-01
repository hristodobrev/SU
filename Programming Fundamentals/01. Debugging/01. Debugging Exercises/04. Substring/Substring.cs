namespace _04.Substring
{
    using System;

    class Substring
    {
        static void Main()
        {
            string text = Console.ReadLine();
            int jump = int.Parse(Console.ReadLine()) + 1;

            const char Search = 'p';
            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                if (currentChar.Equals(Search))
                {
                    hasMatch = true;

                    jump = Math.Min(jump, text.Length - i);

                    string matchedString = text.Substring(i, jump);
                    Console.WriteLine(matchedString);

                    i += jump - 1;
                }

            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}

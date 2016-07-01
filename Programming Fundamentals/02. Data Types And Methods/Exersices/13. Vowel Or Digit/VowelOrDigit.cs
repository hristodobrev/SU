namespace _13.Vowel_Or_Digit
{
    using System;

    class VowelOrDigit
    {
        static void Main()
        {
            char symbol = Console.ReadLine()[0];
            bool isVowel = false;
            bool isDigit = false;

            switch (symbol)
            {
                case 'a':
                case 'e':
                case 'y':
                case 'u':
                case 'o':
                case 'i':
                    isVowel = true;
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    isDigit = true;
                    break;
            }

            if (isVowel)
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine(isDigit ? "digit" : "other");
            }
        }
    }
}

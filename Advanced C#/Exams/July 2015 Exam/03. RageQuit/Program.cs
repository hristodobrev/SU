using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _03.RageQuit
{
    class RageQuit
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"([\D]+)([\d]+)";
            var regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            StringBuilder builder = new StringBuilder();

            foreach (Match match in matches)
            {
                StringBuilder sb = new StringBuilder();
                var message = match.Groups[1].Value.ToUpper();
                var numberOfRepetitions = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < numberOfRepetitions; i++)
                {
                    sb.Append(message);
                }

                builder.Append(sb);
            }

            int count = builder.ToString().Distinct().Count();

            Console.WriteLine("Unique symbols used: {0}", count);
            Console.WriteLine(builder);
        }
    }
}

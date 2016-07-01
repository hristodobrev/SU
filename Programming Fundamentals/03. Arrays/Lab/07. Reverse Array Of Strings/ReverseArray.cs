namespace _07.Reverse_Array_Of_Strings
{
    using System;

    class ReverseArray
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length / 2; i++)
            {
                var temp = input[i];
                input[i] = input[input.Length - i - 1];
                input[input.Length - i - 1] = temp;
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}

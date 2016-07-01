namespace _15.Comparing_Floats
{
    using System;

    class ComparingFloats
    {
        static void Main()
        {
            const float Eps = 0.000001f;

            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            if (Math.Abs(firstNumber - secondNumber) < Eps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}

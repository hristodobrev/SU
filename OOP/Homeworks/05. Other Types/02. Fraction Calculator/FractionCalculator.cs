namespace _02.Fraction_Calculator
{
    using System;

    class FractionCalculator
    {
        static void Main()
        {
            Fraction fraction1 = new Fraction(8, 10);
            Fraction fraction2 = new Fraction(4, 0);
            Fraction result = fraction1 - fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);
        }
    }
}

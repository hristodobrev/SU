using System;
class NumberCalculations
{
    static void Main()
    {
        // Input
        string[] stringNumbers = Console.ReadLine().Split();
        double[] numbers = new double[stringNumbers.Length];
        for (int i = 0; i < stringNumbers.Length; i++)
        {
            numbers[i] = double.Parse(stringNumbers[i]);
        }

        // Output
        Console.WriteLine("Min: {0}", GetMin(numbers));
        Console.WriteLine("Max: {0}", GetMax(numbers));
        Console.WriteLine("Average: {0}", GetAverage(numbers));
        Console.WriteLine("Sum: {0}", GetSum(numbers));
        Console.WriteLine("Product: {0}", GetProduct(numbers));

    }

    // Logic

    static double GetMax(double[] numbers)
    {
        double maxNumber = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > maxNumber)
            {
                maxNumber = numbers[i];
            }
        }
        return maxNumber;
    }

    static double GetMin(double[] numbers)
    {
        double minNumber = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < minNumber)
            {
                minNumber = numbers[i];
            }
        }
        return minNumber;
    }

    static double GetSum(double[] numbers)
    {
        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }

    static double GetAverage(double[] numbers)
    {
        return GetSum(numbers) / numbers.Length;
    }

    static double GetProduct(double[] numbers)
    {
        double product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        return product;
    }

}
namespace _02.Interest_Calculator
{
    using System;

    public class Program
    {
        private const int n = 12;

        static void Main()
        {
            Console.WriteLine("Input format{money}{interest}{years}{type}");

            while (true)
            {
                string[] commandargs = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (commandargs[0].Equals("end"))
                {
                    break;
                }

                decimal money = decimal.Parse(commandargs[0]);
                double interest = double.Parse(commandargs[1]);
                int years = int.Parse(commandargs[2]);

                InterestCalculator calculator = null;

                switch (commandargs[3])
                {
                    case "compound":
                        calculator = new InterestCalculator(money, interest, years, new CalculateInterestDelegate(GetCompoundInterest));
                        break;
                    case "simple":
                        calculator = new InterestCalculator(money, interest, years, new CalculateInterestDelegate(GetSimpleInterest));
                        break;
                }

                Console.WriteLine("{0:F4}", calculator.GetInterest());
            }
        }

        private static double GetSimpleInterest(decimal sum, double interest, int years)
        {
            return (double) sum * (1 + (interest / 100) * years);
        }

        private static double GetCompoundInterest(decimal sum, double interest, int years)
        {
            return (double)sum * Math.Pow(1 + ((interest / 100) / n), years * n);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace _02.Performance_of_Operations
{
    using System.Diagnostics;

    class CalculateTimes
    {
        static void Main(string[] args)
        {
            TimeSpan intAddOperationAverageTime = GetIntOperationAverage("add");
            Console.WriteLine("Add Operation Average Time For Integer: " + intAddOperationAverageTime);

            TimeSpan intSubtractOperationAverageTime = GetIntOperationAverage("subtract");
            Console.WriteLine("Subtract Operation Average Time For Integer: " + intSubtractOperationAverageTime);

            TimeSpan intPrefixOperationAverageTime = GetIntOperationAverage("prefix");
            Console.WriteLine("Prefix Operation Average Time For Integer: " + intPrefixOperationAverageTime);

            TimeSpan intPostfixOperationAverageTime = GetIntOperationAverage("postfix");
            Console.WriteLine("Postfix Operation Average Time For Integer: " + intPostfixOperationAverageTime);

            TimeSpan intIncrementOperationAverageTime = GetIntOperationAverage("increment");
            Console.WriteLine("Increment Operation Average Time For Integer: " + intIncrementOperationAverageTime);

            TimeSpan intMultiplyOperationAverageTime = GetIntOperationAverage("multiply");
            Console.WriteLine("Multiply Operation Average Time For Integer: " + intMultiplyOperationAverageTime);

            TimeSpan intDivideOperationAverageTime = GetIntOperationAverage("divide");
            Console.WriteLine("Divide Operation Average Time For Integer: " + intDivideOperationAverageTime);
            Console.WriteLine();


            // Get average times for long
            TimeSpan longAddOperationAverageTime = GetLongOperationAverage("add");
            Console.WriteLine("Add Operation Average Time For Long: " + longAddOperationAverageTime);

            TimeSpan longSubtractOperationAverageTime = GetLongOperationAverage("subtract");
            Console.WriteLine("Subtract Operation Average Time For Long: " + longSubtractOperationAverageTime);

            TimeSpan longPrefixOperationAverageTime = GetLongOperationAverage("prefix");
            Console.WriteLine("Prefix Operation Average Time For Long: " + longPrefixOperationAverageTime);

            TimeSpan longPostfixOperationAverageTime = GetLongOperationAverage("postfix");
            Console.WriteLine("Postfix Operation Average Time For Long: " + longPostfixOperationAverageTime);

            TimeSpan longIncrementOperationAverageTime = GetLongOperationAverage("increment");
            Console.WriteLine("Increment Operation Average Time For Long: " + longIncrementOperationAverageTime);

            TimeSpan longMultiplyOperationAverageTime = GetLongOperationAverage("multiply");
            Console.WriteLine("Multiply Operation Average Time For Long: " + longMultiplyOperationAverageTime);

            TimeSpan longDivideOperationAverageTime = GetLongOperationAverage("divide");
            Console.WriteLine("Divide Operation Average Time For Long: " + longDivideOperationAverageTime);
            Console.WriteLine();


            // Get average times for double
            TimeSpan doubleAddOperationAverageTime = GetDoubleOperationAverage("add");
            Console.WriteLine("Add Operation Average Time For Double: " + doubleAddOperationAverageTime);

            TimeSpan doubleSubtractOperationAverageTime = GetDoubleOperationAverage("subtract");
            Console.WriteLine("Subtract Operation Average Time For Double: " + doubleSubtractOperationAverageTime);

            TimeSpan doublePrefixOperationAverageTime = GetDoubleOperationAverage("prefix");
            Console.WriteLine("Prefix Operation Average Time For Double: " + doublePrefixOperationAverageTime);

            TimeSpan doublePostfixOperationAverageTime = GetDoubleOperationAverage("postfix");
            Console.WriteLine("Postfix Operation Average Time For Double: " + doublePostfixOperationAverageTime);

            TimeSpan doubleIncrementOperationAverageTime = GetDoubleOperationAverage("increment");
            Console.WriteLine("Increment Operation Average Time For Double: " + doubleIncrementOperationAverageTime);

            TimeSpan doubleMultiplyOperationAverageTime = GetDoubleOperationAverage("multiply");
            Console.WriteLine("Multiply Operation Average Time For Double: " + doubleMultiplyOperationAverageTime);

            TimeSpan doubleDivideOperationAverageTime = GetDoubleOperationAverage("divide");
            Console.WriteLine("Divide Operation Average Time For Double: " + doubleDivideOperationAverageTime);
            Console.WriteLine();


            // Get average times for decimal
            TimeSpan decimalAddOperationAverageTime = GetDecimalOperationAverage("add");
            Console.WriteLine("Add Operation Average Time For Decimal: " + decimalAddOperationAverageTime);

            TimeSpan decimalSubtractOperationAverageTime = GetDecimalOperationAverage("subtract");
            Console.WriteLine("Subtract Operation Average Time For Decimal: " + decimalSubtractOperationAverageTime);

            TimeSpan decimalPrefixOperationAverageTime = GetDecimalOperationAverage("prefix");
            Console.WriteLine("Prefix Operation Average Time For Decimal: " + decimalPrefixOperationAverageTime);

            TimeSpan decimalPostfixOperationAverageTime = GetDecimalOperationAverage("postfix");
            Console.WriteLine("Postfix Operation Average Time For Decimal: " + decimalPostfixOperationAverageTime);

            TimeSpan decimalIncrementOperationAverageTime = GetDecimalOperationAverage("increment");
            Console.WriteLine("Increment Operation Average Time For Decimal: " + decimalIncrementOperationAverageTime);

            TimeSpan decimalMultiplyOperationAverageTime = GetDecimalOperationAverage("multiply");
            Console.WriteLine("Multiply Operation Average Time For Decimal: " + decimalMultiplyOperationAverageTime);

            TimeSpan decimalDivideOperationAverageTime = GetDecimalOperationAverage("divide");
            Console.WriteLine("Divide Operation Average Time For Decimal: " + decimalDivideOperationAverageTime);
            Console.WriteLine();


            // Get average times for double [functions]
            TimeSpan doubleSqrtFunctionAverageTime = GetDoubleFunctionsAverage("sqrt");
            Console.WriteLine("Sqrt Function Average Time For Double: " + doubleSqrtFunctionAverageTime);

            TimeSpan doubleLogFunctionAverageTime = GetDoubleFunctionsAverage("log");
            Console.WriteLine("Log Function Average Time For Double: " + doubleLogFunctionAverageTime);

            TimeSpan doubleSinFunctionAverageTime = GetDoubleFunctionsAverage("sin");
            Console.WriteLine("Sin Function Average Time For Double: " + doubleSinFunctionAverageTime);
            Console.WriteLine();


            // Get average times for decimal [functions]
            TimeSpan decimalSqrtFunctionAverageTime = GetDecimalFunctionsAverage("sqrt");
            Console.WriteLine("Sqrt Function Average Time For Decimal: " + decimalSqrtFunctionAverageTime);

            TimeSpan decimalLogFunctionAverageTime = GetDecimalFunctionsAverage("log");
            Console.WriteLine("Log Function Average Time For Decimal: " + decimalLogFunctionAverageTime);

            TimeSpan decimalSinFunctionAverageTime = GetDecimalFunctionsAverage("sin");
            Console.WriteLine("Sin Function Average Time For Decimal: " + decimalSinFunctionAverageTime);
        }

        private static TimeSpan GetIntOperationAverage(string operation)
        {
            Stopwatch timer = new Stopwatch();

            List<TimeSpan> times = new List<TimeSpan>();

            int a = 1;
            for (int i = 0; i < 5000; i++)
            {
                timer.Restart();
                timer.Start();
                for (int j = 0; j < 100; j++)
                {
                    switch (operation)
                    {
                        case "add":
                            a = a + 500000;
                            break;
                        case "subtract":
                            a = a - 500000;
                            break;
                        case "prefix":
                            ++a;
                            break;
                        case "postfix":
                            a++;
                            break;
                        case "increment":
                            a += 500000;
                            break;
                        case "multiply":
                            a = a * 500000;
                            break;
                        case "divide":
                            a = a / 500000;
                            break;
                    }
                }
                timer.Stop();
                times.Add(timer.Elapsed);
            }

            double averageTicks = times.Average(timespan => timespan.Ticks);
            TimeSpan average = new TimeSpan(Convert.ToInt64(averageTicks));

            return average;
        }

        private static TimeSpan GetLongOperationAverage(string operation)
        {
            Stopwatch timer = new Stopwatch();

            List<TimeSpan> times = new List<TimeSpan>();

            long a = 1;
            for (int i = 0; i < 5000; i++)
            {
                timer.Restart();
                timer.Start();
                for (int j = 0; j < 100; j++)
                {
                    switch (operation)
                    {
                        case "add":
                            a = a + 500000;
                            break;
                        case "subtract":
                            a = a - 500000;
                            break;
                        case "prefix":
                            ++a;
                            break;
                        case "postfix":
                            a++;
                            break;
                        case "increment":
                            a += 500000;
                            break;
                        case "multiply":
                            a = a * 500000;
                            break;
                        case "divide":
                            a = a / 500000;
                            break;
                    }
                }
                timer.Stop();
                times.Add(timer.Elapsed);
            }

            double averageTicks = times.Average(timespan => timespan.Ticks);
            TimeSpan average = new TimeSpan(Convert.ToInt64(averageTicks));

            return average;
        }

        private static TimeSpan GetDoubleOperationAverage(string operation)
        {
            Stopwatch timer = new Stopwatch();

            List<TimeSpan> times = new List<TimeSpan>();

            double a = 1.0;
            for (int i = 0; i < 5000; i++)
            {
                timer.Restart();
                timer.Start();
                for (int j = 0; j < 100; j++)
                {
                    switch (operation)
                    {
                        case "add":
                            a = a + 500000;
                            break;
                        case "subtract":
                            a = a - 500000;
                            break;
                        case "prefix":
                            ++a;
                            break;
                        case "postfix":
                            a++;
                            break;
                        case "increment":
                            a += 500000;
                            break;
                        case "multiply":
                            a = a * 500000;
                            break;
                        case "divide":
                            a = a / 500000;
                            break;
                    }
                }
                timer.Stop();
                times.Add(timer.Elapsed);
            }

            double averageTicks = times.Average(timespan => timespan.Ticks);
            TimeSpan average = new TimeSpan(Convert.ToInt64(averageTicks));

            return average;
        }

        private static TimeSpan GetDecimalOperationAverage(string operation)
        {
            Stopwatch timer = new Stopwatch();

            List<TimeSpan> times = new List<TimeSpan>();

            for (int i = 0; i < 5000; i++)
            {
                timer.Restart();
                timer.Start();
                decimal a = 1.0m;
                for (int j = 0; j < 100; j++)
                {
                    switch (operation)
                    {
                        case "add":
                            a = a + 500000;
                            break;
                        case "subtract":
                            a = a - 500000;
                            break;
                        case "prefix":
                            ++a;
                            break;
                        case "postfix":
                            a++;
                            break;
                        case "increment":
                            a += 500000;
                            break;
                        case "multiply":
                            a = a * 1.1m;
                            break;
                        case "divide":
                            a = a / 500000;
                            break;
                    }
                }
                timer.Stop();
                times.Add(timer.Elapsed);
            }

            double averageTicks = times.Average(timespan => timespan.Ticks);
            TimeSpan average = new TimeSpan(Convert.ToInt64(averageTicks));

            return average;
        }

        private static TimeSpan GetDecimalFunctionsAverage(string function)
        {
            Stopwatch timer = new Stopwatch();

            List<TimeSpan> times = new List<TimeSpan>();

            for (int i = 0; i < 5000; i++)
            {
                timer.Restart();
                timer.Start();
                decimal a = 1.0m;
                for (int j = 0; j < 100; j++)
                {
                    switch (function)
                    {
                        case "sqrt":
                            Math.Sqrt((double)a);
                            break;
                        case "log":
                            Math.Log((double)a);
                            break;
                        case "sin":
                            Math.Sin((double)a);
                            break;
                    }
                }
                timer.Stop();
                times.Add(timer.Elapsed);
            }

            double averageTicks = times.Average(timespan => timespan.Ticks);
            TimeSpan average = new TimeSpan(Convert.ToInt64(averageTicks));

            return average;
        }

        private static TimeSpan GetDoubleFunctionsAverage(string function)
        {
            Stopwatch timer = new Stopwatch();

            List<TimeSpan> times = new List<TimeSpan>();

            for (int i = 0; i < 5000; i++)
            {
                timer.Restart();
                timer.Start();
                double a = 1.0;
                for (int j = 0; j < 100; j++)
                {
                    switch (function)
                    {
                        case "sqrt":
                            Math.Sqrt(a);
                            break;
                        case "log":
                            Math.Log(a);
                            break;
                        case "sin":
                            Math.Sin(a);
                            break;
                    }
                }
                timer.Stop();
                times.Add(timer.Elapsed);
            }

            double averageTicks = times.Average(timespan => timespan.Ticks);
            TimeSpan average = new TimeSpan(Convert.ToInt64(averageTicks));

            return average;
        }
    }
}

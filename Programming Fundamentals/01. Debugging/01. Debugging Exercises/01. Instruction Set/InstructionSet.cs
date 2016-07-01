namespace _01.Instruction_Set
{
    using System;

    class InstructionSet
    {
        static void Main()
        {
            string opCode = Console.ReadLine();

            while (opCode.ToLower() != "end")
            {
                string[] codeArgs = opCode.Split(' ');

                switch (codeArgs[0])
                {
                    case "INC":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        Console.WriteLine(++operandOne);
                        break;
                    }
                    case "DEC":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        Console.WriteLine(--operandOne);
                        break;
                    }
                    case "ADD":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        long operandTwo = long.Parse(codeArgs[2]);
                        Console.WriteLine(operandOne + operandTwo);
                        break;
                    }
                    case "MLA":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        long operandTwo = long.Parse(codeArgs[2]);
                        Console.WriteLine((ulong)(operandOne * operandTwo));
                        break;
                    }
                }

                opCode = Console.ReadLine();
            }
        }
    }
}
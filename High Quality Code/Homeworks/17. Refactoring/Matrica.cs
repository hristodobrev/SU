namespace GameFifteen
{
    using System;
    using System.IO;
    using System.Text;

    class Matrix
    {
        static void Main(string[] args)
        {
            int size = GetInput();

            int[,] matrix = new int[size, size];
            int value = 1;
            int y = 0;
            int x = 0;
            int directionX = 1;
            int directionY = 1;

            IterateMatrix(matrix, y, x, ref value, directionX, size, directionY);

            value++;
            FindCell(matrix, out y, out x);

            // Swap sides of matrix when the right side is filled
            if (x != 0 && y != 0)
            {
                directionX = 1;
                directionY = 1;
                IterateMatrix(matrix, y, x, ref value, directionX, size, directionY);
            }

            string result = GetResult(matrix);
            Console.WriteLine(result);

            WriteTestsOnFile(size, result);
        }

        public static void WriteTestsOnFile(int input, string output)
        {
            using (var writer = new StreamWriter("../../tests.txt", true))
            {
                writer.WriteLine("Input: " + input);
                writer.WriteLine("Output:");
                writer.WriteLine(output);
                writer.WriteLine(new string('-', 30));
            }
        }

        public static int GetInput()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();

            int result = 0;
            while (!int.TryParse(input, out result) || result < 0 || result > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return result;
        }

        public static string GetResult(int[,] matrix)
        {
            StringBuilder result = new StringBuilder();
            int size = matrix.GetLength(0);
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    result.AppendFormat("{0,3}", matrix[row, col]);
                }
                result.AppendLine();
            }

            return result.ToString();
        }

        private static void IterateMatrix(int[,] matrix, int y, int x, ref int value, int directionX, int n, int directionY)
        {
            while (true)
            {
                matrix[y, x] = value;

                if (!Check(matrix, y, x))
                {
                    break;
                }

                if (y + directionX >= n || y + directionX < 0 || x + directionY >= n || x + directionY < 0 ||
                    matrix[y + directionX, x + directionY] != 0)
                {
                    while (y + directionX >= n || y + directionX < 0 || x + directionY >= n || x + directionY < 0 ||
                           matrix[y + directionX, x + directionY] != 0)
                    {
                        ChangeDirection(matrix, ref directionY, ref directionX);
                    }
                }

                y += directionX;
                x += directionY;
                value++;
            }
        }

        private static void ChangeDirection(int[,] matrix, ref int dy, ref int dx)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int cd = 0;
            for (int count = 0; count < 8; count++)
            {
                if (dirY[count] == dy && dirX[count] == dx)
                {
                    cd = count;
                    break;
                }
            }

            if (cd == 7)
            {
                dy = dirY[0];
                dx = dirX[0];
                return;
            }

            dy = dirY[cd + 1];
            dx = dirX[cd + 1];
        }

        private static bool Check(int[,] arr, int y, int x)
        {
            int[] dirY = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirX = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }

                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (arr[y + dirY[i], x + dirX[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindCell(int[,] arr, out int y, out int x)
        {
            x = 0;
            y = 0;
            for (int currentY = 0; currentY < arr.GetLength(0); currentY++)
            {
                for (int currentX = 0; currentX < arr.GetLength(0); currentX++)
                {
                    if (arr[currentY, currentX] == 0)
                    {
                        y = currentY;
                        x = currentX;
                        return;
                    }
                }
            }
        }
    }
}

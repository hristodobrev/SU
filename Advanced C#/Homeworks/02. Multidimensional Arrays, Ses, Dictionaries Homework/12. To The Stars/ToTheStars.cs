using System;
using System.Linq;
class ToTheStars
{
    static void Main()
    {
        // Input
        string[] firstStarSystem = Console.ReadLine().Split();
        string[] secondStarSystem = Console.ReadLine().Split();
        string[] thirdStarSystem = Console.ReadLine().Split();

        int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
        
        int moves = int.Parse(Console.ReadLine());
        
        // Logic
        
        for (int i = 0; i < moves + 1; i++)
        {
            int check = 0;
            if (checkRadius(double.Parse(firstStarSystem[1]), double.Parse(firstStarSystem[2]), coordinates))
            {
                Console.Write(firstStarSystem[0].ToLower());
                check++;
            }
            if (checkRadius(double.Parse(secondStarSystem[1]), double.Parse(secondStarSystem[2]), coordinates))
            {
                Console.Write(secondStarSystem[0].ToLower());
                check++;
            }
            if (checkRadius(double.Parse(thirdStarSystem[1]), double.Parse(thirdStarSystem[2]), coordinates))
            {
                Console.Write(thirdStarSystem[0].ToLower());
                check++;
            }
            if (check == 0)
            {
                Console.Write("space");
            }
            Console.WriteLine();
            coordinates[1]++;
        }
    }

    static bool checkRadius(double x, double y, int[] coordinates)
    {
        return coordinates[0] <= x + 1 && coordinates[0] >= x - 1 && coordinates[1] <= y + 1 && coordinates[1] >= y - 1;
    }
}
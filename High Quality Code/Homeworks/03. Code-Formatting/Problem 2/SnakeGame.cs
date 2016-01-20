using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

class SnakeGame
{
    // Structuring Position
    struct Position
    {
        public int row;
        public int col;
        public Position(int col, int row)
        {
            this.row = row;
            this.col = col;
        }
    }

    // Declaring new Random
    static Random rand = new Random();

    // Declaring snakeElements variable which will hold the snake elements positions
    static Queue<Position> snakeElements = new Queue<Position>();

    static List<Position> obstacles = new List<Position>();

    // Declaring bool that checks if the player is dead
    static bool isDead = false;

    // Declaring direction parameters
    static byte left = 0;
    static byte up = 1;
    static byte right = 2;
    static byte down = 3;
    static int direction = right;
    static Position[] directions = 
    {
        new Position(-1, 0),
        new Position(0, -1),
        new Position(1, 0),
        new Position(0, 1)
    };

    // Generating food and obstacles positions
    static Position foodPosition = new Position();
    static Position obstaclePosition = new Position();

    // Keeping window dimensions in variables
    static int width = Console.WindowWidth;
    static int height = Console.WindowHeight;

    static void Main()
    {
        // Changing the console colors
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.BufferHeight = height;
        Console.BufferWidth = width;

        // Generating the initial snake elements positions
        for (int i = 0; i < 6; i++)
        {
            snakeElements.Enqueue(new Position(i, 3));
        }

        GenerateFood();

        // Starting game cycle
        while (!isDead)
        {
            // Clearing the last element of the snake after every move
            Console.SetCursorPosition(snakeElements.First().col, snakeElements.First().row);
            Console.Write(" ");

            // Checks for an available key and if there is so changing the snake direction
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (direction != right)
                    {
                        direction = left;
                    }
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (direction != down)
                    {
                        direction = up;
                    }
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (direction != left)
                    {
                        direction = right;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (direction != up)
                    {
                        direction = down;
                    }
                }
            }

            // Getting the snake head position and next move position
            Position snakeHead = snakeElements.Last();
            Position snakeNextPosition = new Position(snakeHead.col + directions[direction].col, snakeHead.row + directions[direction].row);

            // getting the conditions wheather the snake is dead or no
            isDead =
                snakeElements.Contains(snakeNextPosition)
                || obstacles.Contains(snakeNextPosition)
                || snakeNextPosition.col > width - 1
                || snakeNextPosition.col < 0
                || snakeNextPosition.row > height - 1
                || snakeNextPosition.row < 0;

            // Checks whether the snake is dead
            if (isDead)
            {
                Console.SetCursorPosition(width / 2 - 5, height / 2);
                Console.WriteLine("Game Over");
                Environment.Exit(0);
            }

            // Checks whether the snake has eaten an apple
            if (!snakeNextPosition.Equals(foodPosition))
            {
                snakeElements.Dequeue();
            }
            else
            {
                GenerateFood();
                GenerateObstacle();
            }

            // Prints the snake next position
            snakeElements.Enqueue(snakeNextPosition);
            PrintSnake();
            Thread.Sleep(100);
        }

    }

    static void GenerateFood()
    {
        foodPosition = new Position(rand.Next(width), rand.Next(height));
        while (snakeElements.Contains(foodPosition) || obstacles.Contains(foodPosition))
        {
            foodPosition = new Position(rand.Next(width), rand.Next(height));
        }
        Console.SetCursorPosition(foodPosition.col, foodPosition.row);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("o");
        Console.ForegroundColor = ConsoleColor.Green;
    }

    static void GenerateObstacle()
    {
        obstaclePosition = new Position(rand.Next(width), rand.Next(height));
        while (snakeElements.Contains(obstaclePosition) || obstaclePosition.Equals(foodPosition))
        {
            obstaclePosition = new Position(rand.Next(width), rand.Next(height));
        }
        Console.SetCursorPosition(obstaclePosition.col, obstaclePosition.row);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("#");
        Console.ForegroundColor = ConsoleColor.Green;
        obstacles.Add(obstaclePosition);
    }

    static void PrintSnake()
    {
        foreach (Position position in snakeElements)
        {
            if (position.Equals(snakeElements.Last()))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.SetCursorPosition(position.col, position.row);
            Console.Write("o");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
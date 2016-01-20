using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

class SnakeGame
{
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

    static Random rand = new Random();

    static Queue<Position> snakeElements = new Queue<Position>();

    static List<Position> obstacles = new List<Position>();

    static bool isDead = false;

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

    static Position foodPosition = new Position();
    static Position obstaclePosition = new Position();

    static int width = Console.WindowWidth;
    static int height = Console.WindowHeight;

    static void Main()
    {
        Console.BufferHeight = height;
        Console.BufferWidth = width;

        // Generating the initial snake elements positions
        for (int i = 0; i < 6; i++)
        {
            snakeElements.Enqueue(new Position(i, 3));
        }

        GenerateFood();

        while (!isDead)
        {
            // Clearing the last element of the snake after every move
            Console.SetCursorPosition(snakeElements.First().col, snakeElements.First().row);
            Console.Write(" ");

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

            Position snakeHead = snakeElements.Last();
            Position snakeNextPosition = new Position(snakeHead.col + directions[direction].col, snakeHead.row + directions[direction].row);

            // Checks whether the snake has collided
            isDead =
                snakeElements.Contains(snakeNextPosition)
                || obstacles.Contains(snakeNextPosition)
                || snakeNextPosition.col > width - 1
                || snakeNextPosition.col < 0
                || snakeNextPosition.row > height - 1
                || snakeNextPosition.row < 0;

            if (isDead)
            {
                Console.SetCursorPosition(width / 2 - 5, height / 2);
                Console.WriteLine("Game Over");
                Environment.Exit(0);
            }

            if (!snakeNextPosition.Equals(foodPosition))
            {
                snakeElements.Dequeue();
            }
            else
            {
                GenerateFood();
                GenerateObstacle();
            }

            snakeElements.Enqueue(snakeNextPosition);
            PrintSnake();
            Thread.Sleep(100);
        }

    }

    static void PrintElement(char element, int col, int row)
    {
        Console.SetCursorPosition(col, row);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(element);
        Console.ForegroundColor = ConsoleColor.Green;
    }

    static void GenerateFood()
    {
        foodPosition = new Position(rand.Next(width), rand.Next(height));

        while (snakeElements.Contains(foodPosition) || obstacles.Contains(foodPosition))
        {
            foodPosition = new Position(rand.Next(width), rand.Next(height));
        }

        PrintElement('o', foodPosition.col, foodPosition.row);
    }

    static void GenerateObstacle()
    {
        obstaclePosition = new Position(rand.Next(width), rand.Next(height));

        while (snakeElements.Contains(obstaclePosition) || obstaclePosition.Equals(foodPosition))
        {
            obstaclePosition = new Position(rand.Next(width), rand.Next(height));
        }

        PrintElement('#', obstaclePosition.col, obstaclePosition.row);

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

            PrintElement('o', position.col, position.row);
        }
    }
}
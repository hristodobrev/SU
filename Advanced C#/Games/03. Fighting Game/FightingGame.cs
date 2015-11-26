using System;
using System.Threading;
class FightingGame
{

    static string[] menuItems = { "Play", "Instructions", "Exit", "Wellcome to Fighting Game!", new string('-', 28), "[B] - Shield", "[Enter] - Attack", "[Escape] - Back", "Back" };
    static string[] menuItemsSpaces = 
    { 
        new string(' ', ((Console.BufferWidth - menuItems[0].Length) / 2) - 2),
        new string(' ', ((Console.BufferWidth - menuItems[1].Length) / 2) - 2),
        new string(' ', ((Console.BufferWidth - menuItems[2].Length) / 2) - 2),
        new string(' ', ((Console.BufferWidth - menuItems[3].Length) / 2) - 2),
        new string(' ', ((Console.BufferWidth - menuItems[4].Length) / 2) - 2),
    };
    static int menuSelectorPosition = 0;
    static int scores = 0;
    static int gold = 0;
    static int playerAttackPower = 2;
    static int playerMaxAttack = 5 * playerAttackPower;
    static int playerMinAttack = playerMaxAttack - (playerAttackPower * 2);
    static int enemyAttackPower = enemyStrength;
    static int enemyMaxAttack = 5 * enemyAttackPower;
    static int enemyMinAttack = enemyMaxAttack - (enemyAttackPower * 2);
    static int enemyMoneyGiven = 30;
    static int enemyStrength = 1;
    static int playerHealth = 50;
    static int currentPlayerHealth = 50;
    static int enemyHealth = 50 * enemyStrength;
    static Random rand = new Random();

    static double criticalChance = 0.01;

    static void Main()
    {
        Console.CursorVisible = false;
        MainMenu();
    }

    static void MainMenu()
    {
        PrintMainMenu();
    }

    static void PrintGUI()
    {
        Console.SetCursorPosition(3, 4);
        Console.WriteLine("o" + new string('-', 15) + "o");
        Console.SetCursorPosition(3, 5);
        Console.WriteLine("| Player" + new string(' ', 8) + "|");
        Console.SetCursorPosition(3, 6);
        Console.WriteLine("o" + new string('-', 15) + "o");
        Console.SetCursorPosition(3, 7);
        Console.WriteLine("| Health: {0,-6}|", currentPlayerHealth);
        Console.SetCursorPosition(3, 8);
        Console.WriteLine("o" + new string('-', 15) + "o");
        Console.SetCursorPosition(60, 4);
        Console.WriteLine("o" + new string('-', 15) + "o");
        Console.SetCursorPosition(60, 5);
        Console.WriteLine("| Enemy" + new string(' ', 9) + "|");
        Console.SetCursorPosition(60, 6);
        Console.WriteLine("o" + new string('-', 15) + "o");
        Console.SetCursorPosition(60, 7);
        Console.WriteLine("| Health: {0,-6}|", enemyHealth);
        Console.SetCursorPosition(60, 8);
        Console.WriteLine("o" + new string('-', 15) + "o");
    }

    static void GameCycle()
    {
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Enter)
        {
            int currentPlayerAttack = rand.Next(playerMinAttack, playerMaxAttack);
            enemyHealth -= currentPlayerAttack;
            Console.SetCursorPosition(23, 5);
            Console.WriteLine("Attack for {0} damage -> Health - {0}", currentPlayerAttack );
        }
        if (enemyHealth < 0)
        {
            Console.Clear();
            PrintGame();
            Console.SetCursorPosition(23, 5);
            Console.WriteLine("You have won!");
            Console.SetCursorPosition(23, 6);
            Console.WriteLine("You have stolen {0} gold from the enemy.", enemyMoneyGiven);
            gold += enemyMoneyGiven;
            Thread.Sleep(3000);
            MainMenu();
        }
        int currentEnemyAttack = rand.Next(enemyMinAttack, enemyMaxAttack);
        currentPlayerHealth -= currentEnemyAttack;
        Console.SetCursorPosition(23, 5);
        Console.WriteLine("Health - {0} <- Attack for {0} damage", currentEnemyAttack);
        Thread.Sleep(500);
        if (currentPlayerHealth < 0)
        {
            Console.SetCursorPosition(23, 5);
            Console.WriteLine("You have lost!");
            Thread.Sleep(3000);
            MainMenu();
        }
        GameStart();
    }

    static void GameStart()
    {
        PrintGame();
        PrintGUI();
        GameCycle();
    }

    static void SelectEnemyStrength()
    {
        Console.CursorVisible = true;
        Console.SetCursorPosition(1, 3);
        Console.WriteLine("Please type the strength of the enemy.");
        Console.SetCursorPosition(1, 4);
        Console.WriteLine("The bigger number you type, the stronger enemy will");
        Console.SetCursorPosition(1, 5);
        Console.WriteLine("be and the more money you will get for killing it.");
        Console.SetCursorPosition(1, 6);
        enemyStrength = int.Parse(Console.ReadLine());
        enemyAttackPower = enemyStrength;
        enemyMaxAttack = 5 * enemyAttackPower;
        enemyMinAttack = enemyMaxAttack - enemyAttackPower;
        enemyMoneyGiven = 30 * enemyStrength;
        enemyHealth = 50 * enemyStrength;
        currentPlayerHealth = playerHealth;
        Console.CursorVisible = false;
    }

    static void PrintGame()
    {
        Console.Clear();
        for (int i = 0; i < Console.BufferHeight; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("|");
            Console.SetCursorPosition(Console.BufferWidth - 1, i);
            Console.Write("|");
        }
        Console.SetCursorPosition(0, Console.BufferHeight - 1);
        Console.Write("o" + new string('-', Console.BufferWidth - 2) + "o");
        Console.SetCursorPosition(0, 0);
        Console.Write("o" + new string('-', Console.BufferWidth - 2) + "o");
        Console.SetCursorPosition(0, 0);
        Console.Write("o----------------o-----------------o-------------------o----------o------------o", scores);
        Console.WriteLine("| Attack: {0} - {1} | Attack Power: {2} | Crit Chance: {3} | Gold: {4,-3}| Score: {5,-3}", playerMinAttack, playerMaxAttack, playerAttackPower, criticalChance, gold, scores);
        Console.Write("o----------------o-----------------o-------------------o----------o------------o", scores);
    }

    static void PrintMainMenu()
    {
        Console.WindowWidth = 30;
        Console.WindowHeight = 16;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
        Console.Clear();
        for (int i = 0; i < Console.BufferHeight; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("|");
            Console.SetCursorPosition(29, i);
            Console.Write("|");
        }
        Console.Write("o" + new string('-', 28) + "o");
        Console.SetCursorPosition(0, 6 + (menuSelectorPosition * 2));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("o" + new string(' ', ((Console.BufferWidth - menuItems[4].Length) / 2) - 1) + menuItems[4] + new string(' ', ((Console.BufferWidth - menuItems[4].Length) / 2) - 1) + "o");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 6 + ((menuSelectorPosition + 1) * 2));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("o" + new string(' ', ((Console.BufferWidth - menuItems[4].Length) / 2) - 1) + menuItems[4] + new string(' ', ((Console.BufferWidth - menuItems[4].Length) / 2) - 1) + "o");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 0);
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("|" + new string(' ', ((Console.BufferWidth - menuItems[3].Length) / 2) - 1) + menuItems[3] + new string(' ', ((Console.BufferWidth - menuItems[3].Length) / 2) - 1) + "|");
        Console.WriteLine();
        Console.Write("o" + new string('-', 28) + "o");
        Console.WriteLine();
        Console.WriteLine();
        if (menuSelectorPosition == 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.Write("|" + new string(' ', ((Console.BufferWidth - menuItems[0].Length) / 2) - 1) + menuItems[0] + new string(' ', ((Console.BufferWidth - menuItems[0].Length) / 2) - 1) + "|");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        if (menuSelectorPosition == 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.Write("|" + new string(' ', ((Console.BufferWidth - menuItems[1].Length) / 2) - 1) + menuItems[1] + new string(' ', ((Console.BufferWidth - menuItems[1].Length) / 2) - 1) + "|");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        if (menuSelectorPosition == 2)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.Write("|" + new string(' ', ((Console.BufferWidth - menuItems[2].Length) / 2) - 1) + menuItems[2] + new string(' ', ((Console.BufferWidth - menuItems[2].Length) / 2) - 1) + "|");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 0);
        Console.Write("o" + new string('-', 28) + "o");
        UserTurnInMenu();
    }

    static void PrintInstructions()
    {
        Console.Clear();
        for (int i = 1; i < Console.BufferHeight; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("|");
            Console.SetCursorPosition(29, i);
            Console.Write("|");
        }
        Console.SetCursorPosition(0, 11);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("o" + new string(' ', ((Console.BufferWidth - menuItems[4].Length) / 2) - 1) + menuItems[4] + new string(' ', ((Console.BufferWidth - menuItems[4].Length) / 2) - 1) + "o");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 13);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("o" + new string(' ', ((Console.BufferWidth - menuItems[4].Length) / 2) - 1) + menuItems[4] + new string(' ', ((Console.BufferWidth - menuItems[4].Length) / 2) - 1) + "o");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, Console.BufferHeight - 1);
        Console.Write("o" + new string('-', 28) + "o");
        Console.SetCursorPosition(0, 1);
        Console.Write("| " + menuItems[5] + new string(' ', (Console.BufferWidth - menuItems[5].Length) - 3) + "|");
        Console.Write("| " + menuItems[6] + new string(' ', (Console.BufferWidth - menuItems[6].Length) - 3) + "|");
        Console.Write("| " + menuItems[7] + new string(' ', (Console.BufferWidth - menuItems[5].Length) - 6) + "|");
        Console.SetCursorPosition(0, 11);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("|" + new string(' ', ((Console.BufferWidth - menuItems[8].Length) / 2) - 1) + menuItems[8] + new string(' ', ((Console.BufferWidth - menuItems[8].Length) / 2) - 1) + "|");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 0);
        Console.Write("o" + new string('-', 28) + "o");
        ConsoleKeyInfo select = Console.ReadKey();
        if (select.Key == ConsoleKey.Escape || select.Key == ConsoleKey.Enter)
        {
            PrintMainMenu();
        }
        else
        {
            PrintInstructions();
        }
    }

    static void UserTurnInMenu()
    {
        ConsoleKeyInfo select = Console.ReadKey();
        if (select.Key == ConsoleKey.DownArrow && menuSelectorPosition < 2)
        {
            menuSelectorPosition++;
        }
        if (select.Key == ConsoleKey.UpArrow && menuSelectorPosition > 0)
        {
            menuSelectorPosition--;
        }
        if (select.Key == ConsoleKey.Enter)
        {
            switch (menuSelectorPosition)
            {
                case 0:
                    StartGame();
                    break;
                case 1:
                    PrintInstructions();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
        PrintMainMenu();
    }

    private static void StartGame()
    {
        Console.WindowHeight = 30;
        Console.WindowWidth = 80;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
        PrintGame();
        SelectEnemyStrength();
        Console.SetCursorPosition(1, 7);
        Console.WriteLine("You have chosen to fight against enemy of {0} level.", enemyStrength);
        //Counter();
        GameStart();
    }

    static void Counter()
    {
        Console.SetCursorPosition(1, 8);
        Console.WriteLine("Starting in ..3");
        Thread.Sleep(1000);
        Console.SetCursorPosition(1, 8);
        Console.WriteLine("Starting in ..2");
        Thread.Sleep(1000);
        Console.SetCursorPosition(1, 8);
        Console.WriteLine("Starting in ..1");
        Thread.Sleep(1000);
    }

}
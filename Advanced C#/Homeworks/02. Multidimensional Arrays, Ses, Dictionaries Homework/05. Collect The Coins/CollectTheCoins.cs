using System;
using System.Collections.Generic;
using System.Linq;
class CollectTheCoins
{
    static void Main()
    {
        int coinsCollected = 0;
        int wallsHits = 0;
        int x = 0;
        int y = 0;
        char[][] board = new char[4][];
        for (int i = 0; i < 4; i++)
        {
            board[i] = Console.ReadLine().ToCharArray();
        }
        string movement = Console.ReadLine();
        foreach (var move in movement)
        {
            switch (move)
            {
                case 'V':
                    if (y < 3)
                    {
                        if (x < board[y + 1].Count() - 1)
                        {
                            if (board[y + 1][x] == '$')
                            {
                                board[y + 1][x] = 'x';
                                coinsCollected++;
                            }
                            y++;
                        }
                        else 
	                    {
                            wallsHits++;
	                    }
                    }
                    else
                    {
                        wallsHits++;
                    }
                    break;
                case '^':
                    if (y > 0)
                    {
                        if (x < board[y - 1].Count() - 1)
                        {
                            if (board[y - 1][x] == '$')
                            {
                                board[y - 1][x] = 'x';
                                coinsCollected++;
                            }
                            y--;
                        }
                        else
                        {
                            wallsHits++;
                        }
                    }
                    else
                    {
                        wallsHits++;
                    }
                    break;
                case '>':
                    if (x < board[y].Count() - 1)
                    {
                        if (board[y][x + 1] == '$')
                        {
                            board[y][x + 1] = 'x';
                            coinsCollected++;
                        }
                        x++;
                    }
                    else
                    {
                        wallsHits++;
                    }
                    break;
                case '<':
                    if (x > 0)
                    {
                        if (board[y][x - 1] == '$')
                        {
                            board[y][x - 1] = 'x';
                            coinsCollected++;
                        }
                        x--;
                    }
                    else
                    {
                        wallsHits++;
                    }
                    break;
            }
        }
        Console.WriteLine("Coins collected: {0}", coinsCollected);
        Console.WriteLine("Walls hit: {0}", wallsHits);
    }
}
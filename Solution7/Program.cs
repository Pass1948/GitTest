using System;
using System.Drawing;
using System.Numerics;

namespace Solution7
{
    internal class Program
    {
        enum Tile {None, number, player, keyBotten};
        enum KeyMove {Up, Down, Left, Right, None }

        static void Main(string[] args)
        {
            GameRender();
            while (true)
            {
                KeyMove input = GameInput();
                GameRender();                         
            }
        }
        static KeyMove GameInput()
        {
            KeyMove direction;
            ConsoleKeyInfo info = Console.ReadKey();
            switch (info.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    direction = KeyMove.Up;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    direction = KeyMove.Down;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    direction = KeyMove.Left;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    direction = KeyMove.Right;
                    break;
                default:
                    direction = KeyMove.None;
                    break;
            }
            return direction;
        }
        static void GameRender()
        {
            int[,] puzzleNum = new int[5, 5];
            int number = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    puzzleNum[i, j] = number;
                    number++;
                }
            }
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int dest1 = random.Next(0, 5);
                int sour1 = random.Next(0, 5);
                int dest2 = random.Next(0, 5);
                int sour2 = random.Next(0, 5);
                int temp = puzzleNum[dest1, sour1];

                puzzleNum[dest1, sour1] = puzzleNum[dest1, sour2];
                puzzleNum[dest1, sour2] = puzzleNum[dest2, sour1];
                puzzleNum[dest2, sour1] = puzzleNum[dest2, sour2];
                puzzleNum[dest2, sour2] = temp;
            }

            puzzleNum[3, 3] = 0;
            if (puzzleNum[3, 3] != 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (puzzleNum[i, j] == 0)
                        {
                            int temp = puzzleNum[3, 3];
                            puzzleNum[3, 3] = puzzleNum[i, j];
                            puzzleNum[i, j] = temp;
                        }
                    }
                }
            }





        }
    }
}
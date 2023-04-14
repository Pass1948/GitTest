using System;
using System.Drawing;
using System.Numerics;

namespace Solution7
{
    internal class Program
    {
        enum Tile { None, number, player, keyBotten };
        enum KeyMove { Up, Down, Left, Right, None }

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
            int inputCount = 0;
            bool congratulation = false;


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


            while (true)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (puzzleNum[i, j] == 0)
                        {
                            Console.Write("0\t");
                        }
                        else
                        {
                            Console.Write(puzzleNum[i, j] + "\t");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }

                int checkNumber = 1;
                int checkCount = 0;
                if (!congratulation)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (puzzleNum[i, j] == checkNumber)
                            {
                                checkNumber++;
                                checkCount++;
                            }
                        }
                    }
                    if (checkCount % 25 == 0)
                    {
                        congratulation = true;
                        break;
                    }
                }
                else
                {
                    break;
                }

                Console.WriteLine("현재 Input Count : " + inputCount);
                Console.WriteLine("움직일 방향의 숫자를 입력하세요.");
                Console.WriteLine("←(4), →(8), ↑(6), ↓(2)");
                string input = Console.ReadLine();
                int inputNum;
                while (true)
                {
                    if (!int.TryParse(input, out inputNum) || (inputNum != 8 && inputNum != 6 && inputNum != 2 && inputNum != 4))
                    {
                        Console.WriteLine("다시 입력하세요. 이상한거 입력받았음");
                        Console.WriteLine("←(4), →(8), ↑(6), ↓(2)");
                        input = Console.ReadLine();
                        Console.WriteLine();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                if (inputNum == 4)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (puzzleNum[i, j] == 0 && j > 0)
                            {
                                int temp = puzzleNum[i, j];
                                puzzleNum[i, j] = puzzleNum[i, j - 1];
                                puzzleNum[i, j - 1] = temp;
                            }
                        }
                    }
                }
                if (inputNum == 8)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (puzzleNum[i, j] == 0 && i > 0)
                            {
                                int temp = puzzleNum[i, j];
                                puzzleNum[i, j] = puzzleNum[i - 1, j];
                                puzzleNum[i - 1, j] = temp;
                            }
                        }
                    }
                }
                if (inputNum == 6)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (puzzleNum[i, j] == 0 && j < 4)
                            {
                                int temp = puzzleNum[i, j];
                                puzzleNum[i, j] = puzzleNum[i, j + 1];
                                puzzleNum[i, j + 1] = temp;
                                break;
                            }
                        }
                    }
                }
                if (inputNum == 2)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (puzzleNum[i, j] == 0 && i < 4)
                            {
                                int temp = puzzleNum[i, j];
                                puzzleNum[i, j] = puzzleNum[i + 1, j];
                                puzzleNum[i + 1, j] = temp;
                                break;
                            }
                        }
                    }
                }
                Console.Clear();
                inputCount++;
            }
        }
    }
}
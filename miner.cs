﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace mapbrodilka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool isPlaying = true;
            char[,] map = new char[,]
            {
                {'#','#','#','#','#','#','#','#','#','#'},
                {'#','.','.','.','.','.','.','#','.','#'},
                {'#','.','.','.','.','.','.','#','.','#'},
                {'#','.','.','#','.','.','.','#','.','#'},
                {'#','.','.','#','.','.','.','.','.','#'},
                {'#','.','#','#','.','.','.','.','.','#'},
                {'#','.','#','.','.','.','.','.','.','#'},
                {'#','.','#','.','.','.','.','.','.','#'},
                {'#','.','#','.','.','#','.','.','.','#'},
                {'#','#','#','#','#','#','#','#','#','#'}
            };

            int positionPlayerX = 1;
            int positionPlayerY = 1;
            int directionX = 0;
            int directionY = 0;

            int totalDots = CountDots(map);

            DrawMap(map);
            DrawPlayer(positionPlayerX, positionPlayerY);

            while (isPlaying)
            {
                Console.SetCursorPosition(11, 11);
                Console.WriteLine($"Cчет{totalDots}");
                ConsoleKeyInfo key = Console.ReadKey(true);

                GetDirection(key, out directionX, out directionY);

                if (directionX != 0 || directionY != 0)
                {
                    if (map[positionPlayerX + directionX, positionPlayerY + directionY] != '#')
                    {
                        playerMovement(ref positionPlayerX, ref positionPlayerY, directionX, directionY);
                        if (map[positionPlayerX, positionPlayerY] == '.')
                        {
                            totalDots--;
                            map[positionPlayerX, positionPlayerY] = ' ';
                        }
                    }
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    isPlaying = false;
                }

                if (totalDots == 0)
                {
                    Console.WriteLine("Поздравляю!Ты скушал все точки");
                    isPlaying = false;
                }
            }
        }

        static void DrawMap(char[,] map)
        {
            Console.Clear();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void DrawPlayer(int positionPlayerX, int positionPlayerY)
        {
            Console.SetCursorPosition(positionPlayerY, positionPlayerX);
            Console.Write('@');
        }

        static void playerMovement(ref int positionPlayerX, ref int positionPlayerY, int directionX, int directionY)
        {
            Console.SetCursorPosition(positionPlayerY, positionPlayerX);
            Console.Write(' ');

            positionPlayerX += directionX;
            positionPlayerY += directionY;

            Console.SetCursorPosition(positionPlayerY, positionPlayerX);
            Console.Write('@');
        }

        static void GetDirection(ConsoleKeyInfo key, out int directionX, out int directionY)
        {
            directionY = 0;
            directionX = 0;

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    break;
                case ConsoleKey.DownArrow:
                    directionX = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    directionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    directionY = 1;
                    break;
            }
        }

        static int CountDots(char[,] map)
        {
            int count = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == '.')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}

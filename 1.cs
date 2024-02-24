using System;
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

            int gamePosX = 11;
            int gamePosY = 11;
            bool isPlaying = true;
            char wallSymbol = '#';
            char emptySymbol = ' ';
            char dotSymbol = '.';
            char playerSymbol = '@';

            char[,] map = new char[,]
            {
            { wallSymbol, wallSymbol, wallSymbol, wallSymbol, wallSymbol, wallSymbol, wallSymbol, wallSymbol, wallSymbol, wallSymbol },
            { wallSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, wallSymbol, dotSymbol, wallSymbol },
            { wallSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, wallSymbol, dotSymbol, wallSymbol },
            { wallSymbol, dotSymbol, dotSymbol, wallSymbol, dotSymbol, dotSymbol, dotSymbol, wallSymbol, dotSymbol, wallSymbol },
            { wallSymbol, dotSymbol, dotSymbol, wallSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, wallSymbol },
            { wallSymbol, dotSymbol, wallSymbol, wallSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, wallSymbol },
            { wallSymbol, dotSymbol, wallSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, wallSymbol },
            { wallSymbol, dotSymbol, wallSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, dotSymbol, wallSymbol },
            { wallSymbol, dotSymbol, wallSymbol, dotSymbol, dotSymbol, wallSymbol, dotSymbol, dotSymbol, dotSymbol, wallSymbol },
            { wallSymbol, wallSymbol, wallSymbol, wallSymbol, wallSymbol, wallSymbol, wallSymbol, wallSymbol, wallSymbol, wallSymbol }
            };

            int positionPlayerX = 1;
            int positionPlayerY = 1;
            int directionX = 0;
            int directionY = 0;

            int totalDots = CountDots(map,dotSymbol);

            DrawMap(map);
            DrawPlayer(positionPlayerX, positionPlayerY);

            while (isPlaying)
            {
                Console.SetCursorPosition(gamePosX, gamePosY);
                Console.WriteLine($"Cчет{totalDots}");
                ConsoleKeyInfo key = Console.ReadKey(true);

                GetDirection(key, out directionX, out directionY);

                if (directionX != 0 || directionY != 0)
                {
                    if (map[positionPlayerX + directionX, positionPlayerY + directionY] != wallSymbol)
                    {
                        MovePlayer(ref positionPlayerX, ref positionPlayerY, directionX, directionY, map, ref totalDots,dotSymbol,emptySymbol);
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

        static void MovePlayer(ref int positionPlayerX, ref int positionPlayerY, int directionX, int directionY, char[,] map, ref int totalDots, char dotSymbol, char emptySymbol)
        {
            Console.SetCursorPosition(positionPlayerY, positionPlayerX);
            Console.Write(' ');

            positionPlayerX += directionX;
            positionPlayerY += directionY;

            Console.SetCursorPosition(positionPlayerY, positionPlayerX);
            Console.Write('@');

            if (map[positionPlayerX, positionPlayerY] == dotSymbol)
            {
                totalDots--;
                map[positionPlayerX, positionPlayerY] = emptySymbol;
            }
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

        static int CountDots(char[,] map,char dotSymbol)
        {
            int count = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == dotSymbol)
                    {
                        count++;
                    }
                }

            }

            return count;
        }
    }
}

  
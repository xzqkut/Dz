using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Render render = new Render();
            Player player = new Player(19, 5, '|');

            render.Draw(player.PositionX, player.PositionY,player.Symbol);
        }
    }

    class Player
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public char Symbol { get; private set; }

        public Player(int positionX,int positionY,char symbol)
        {
            PositionX = positionX;
            PositionY = positionY;
            Symbol = symbol;
        }
    }

    class Render
    {
        public void Draw(int positionX,int positionY,char symbol)
        {
            Console.SetCursorPosition(positionX,positionY);
            Console.WriteLine(symbol);
        }
        
    }
}

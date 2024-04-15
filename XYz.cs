using System;


namespace XYd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Render render = new Render();
            Player player = new Player(19, 5, '@');

            render.Draw(player);
        }
    }

    class Player
    {

        public Player(int positionX,int positionY,char symbol)
        {
            PositionX = positionX;
            PositionY = positionY;
            Symbol = symbol;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public char Symbol { get; private set; }
    }

    class Render
    {
        public void Draw(Player player)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(player.PositionX,player.PositionY);
            Console.WriteLine(player.Symbol);
            Console.ReadKey();
        }
    }
}

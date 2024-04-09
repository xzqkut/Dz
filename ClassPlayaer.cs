using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            player.ShowInfo();
        }
    }
class Player
    {
        private int _health;
        private string _name;
        private int _damage;

        public Player(int health, int damage, string name)
        {
            if (damage < 0)
            {
                damage = 5;
            }
            else
            {
                _damage = damage;
            }

            _health = health;
            _name = name;
            _damage = damage;
        }

        public Player()
        {
            _health = 100;
            _name = "kekwiger";
            _damage = 10;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Игрок имеет {_health}  здоровья, {_damage} урона и его зовут {_name}") ;
        }
    }


}

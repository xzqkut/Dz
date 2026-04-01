using System;
using System.Collections.Generic;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();

            arena.Work();
        }
    }

    
    public static class UserUtils
    {
        private static Random _random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

    }

    class Arena
    {
        private List<Fighter> _fighters;

        public Arena()
        {
            _fighters = new List<Fighter>();

            _fighters.Add(new Barbarian(50, 1000, 100));
            _fighters.Add(new Mage(30, 700, 50));
            _fighters.Add(new Rogue(40, 900, 120));
            _fighters.Add(new Ranger(45, 950, 150));
            _fighters.Add(new Monk(50, 1200, 100));
        }

        public void Work()
        {
           

            Console.WriteLine("Добро пожаловать на арену\nВыберите бойцов");
           
           ShowFighters();

            Console.WriteLine("Выберите первого бойца");

            Fighter firstFighter = ChooseFighter();

            Console.WriteLine("Выберите второго бойца");

            Fighter secondFighter = ChooseFighter();

            StartFight(firstFighter,secondFighter);
           
        }
        private void ShowFightersHealth(Fighter first, Fighter second)
        {
            Console.WriteLine($"{first.TypeFighter}: {first.Health} HP");
            Console.WriteLine($"{second.TypeFighter}: {second.Health} HP");
            Console.WriteLine("----------------------");
        }
        public void StartFight(Fighter firstFighter,Fighter secondFighter)
        {
            while (firstFighter.IsAlive()&& secondFighter.IsAlive())
            {
                firstFighter.ProcessBurn();
                secondFighter.ProcessBurn();

                firstFighter.Attack(secondFighter);

                if (secondFighter.IsAlive())
                {
                    secondFighter.Attack(firstFighter);
                }
                Console.ReadKey();

                ShowFightersHealth(firstFighter, secondFighter);
            }
            if (firstFighter.IsAlive())
            {
                Console.WriteLine($"{firstFighter.TypeFighter} победил");
            }
            else
            {
                Console.WriteLine($"{secondFighter.TypeFighter} победил");
            }
        }

        private Fighter ChooseFighter()
        {
            while (true)
            {
                string chooseFighter = Console.ReadLine();

                if (int.TryParse(chooseFighter, out int index) && IsValidIndex(index))
                {
                    return _fighters[index-1];
                }

                Console.WriteLine("неверный выбор попробуйте еще!");
            }
        }

        private bool IsValidIndex(int index)
        {
            return index>0&&index<=_fighters.Count;
        }

        public void ShowFighters()
        {
            for(int i=0;i<_fighters.Count;i++)
            {
                Console.WriteLine($"{i + 1}-{_fighters[i].TypeFighter}");
            }
        }
    }

    abstract class Fighter
    {
        private int _burnDamage = 0; 
        private int _burnTurns = 0;

        public Fighter(int armor, int health, int damage, string typeFighter)
        {
            Armor = armor;
            Health = health;
            Damage = damage;
            TypeFighter = typeFighter;
        }

        public int Armor {  get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }
        public string TypeFighter { get; private set; }

        public void ApplyBurn(int damage, int turns)
        {
            _burnDamage = damage; _burnTurns=turns;
        }

        public void ProcessBurn()
        {
            if (_burnTurns > 0)
            {
                Console.WriteLine($"{TypeFighter} получает урон от горения {_burnDamage}");
                TakeDamage(_burnDamage);
                _burnTurns--;
            }
        }

        public virtual void Attack(Fighter enemy)
        {
            enemy.TakeDamage(Damage);  
        }

        public virtual void TakeDamage(int damage)
        {
            int finalDamage = damage-Armor;
            if (finalDamage < 0)
            {
                finalDamage = 0;
            }
            Health-=finalDamage;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        protected void Heal(int amount)
        {
            Health += amount;

            Console.WriteLine($"{TypeFighter} восстановил {amount} HP");
        }
    }

    class Mage:Fighter
    {
        private const int FireballCost = 33;
        private const int FireballDamage = 280;

        private int _mana = 100;
        private int _skipTurns = 0;
        
        public Mage(int armor,int health,int damage) : base(armor, health, damage, "МАГ")
        {  
        }

        public override void Attack(Fighter enemy)
        {
            if (_skipTurns > 0)
            {
                Console.WriteLine($"{TypeFighter} копит манну и не может пока атаковать");
                _skipTurns--;
                _mana += 20;
                return;
            }

            if( _mana >= FireballCost)
            {
                _mana -= FireballCost;

                Console.WriteLine($"Гориииии!- {TypeFighter} воспользовался заклинанием");

                enemy.TakeDamage(FireballDamage);

                int burnDamage = (int)(FireballDamage * 0.1);
                enemy.ApplyBurn(burnDamage, 3);
            }
            else
            {
                Console.WriteLine($"{TypeFighter} не хватает маны и он пропускает 2 хода");

                _skipTurns = 2;
            }
        }
    }

    class Barbarian : Fighter
    {
        private int _maxHealth;

        public Barbarian(int armor,int health,int damage):base(armor, health, damage, "ВАРВАР")
        {
            _maxHealth = health;
        }

        public override void Attack(Fighter enemy)
        {
            int lostHealth= _maxHealth - Health;
            int stackRage = lostHealth/100;
            
            if (stackRage >= 5)
            {
                stackRage = 5; 
            }

            double bonusDamage = Damage * stackRage * 0.1;
            double finalDamage = bonusDamage+Damage;

           enemy.TakeDamage((int)finalDamage);
        }
    }

    class Rogue : Fighter
    {
        private const int _dodgeChance = 20;
        public Rogue(int armor, int health, int damage) : base(armor, health, damage, "Разбойник")
        {
        }

        public override void TakeDamage(int damage)
        {
            if (UserUtils.GenerateRandomNumber(1,100) < _dodgeChance)
            {
                Console.WriteLine($"{TypeFighter}, уклонился повезет в следующий раз -_0");
                return;  
            }
            base.TakeDamage(damage);
        }
    }
    
    class Ranger : Fighter
    {
        private const int _chanceHeadshot = 10;
        private const double _crietMultiplier = 2.5;
        public Ranger(int armor, int health, int damage) : base(armor, health, damage, "Рейнджер")
        {
        }

        public override void Attack(Fighter enemy)
        {
            if (UserUtils.GenerateRandomNumber(1, 100) < _chanceHeadshot)
            {
                Console.WriteLine("Сегодня везучий день для рейнджера и он бьет прямо в цель");
                int finalDamage = (int)(Damage * _crietMultiplier);
               enemy.TakeDamage(finalDamage);
            }
            else
            {
                enemy.TakeDamage(Damage);
            }
        }
    }

    class Monk : Fighter
    {

        private const int _heal = 100;
        private  int _injuries = 0;
        public Monk(int armor, int health, int damage) : base(armor, health, damage, "МОНАХ")
        {
        }

        public override void Attack(Fighter enemy)
        {
            enemy.TakeDamage(Damage);

            _injuries++;

            if (_injuries == 3)
            {
               Heal(_heal);
                Console.WriteLine($"Монах медитирует и восстановил здоровье");
                _injuries= 0;
            }

        }
    }
}

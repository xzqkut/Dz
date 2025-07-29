using System;
using System.Collections.Generic;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Croupier croupier = new Croupier();
            Console.WriteLine("Сколько карт выдать игроку?");

            if(int.TryParse(Console.ReadLine(),out int cardCount))
            {
                croupier.GiveCardsToPlayer(cardCount);
                croupier.ShowPlayerCards();
            }
            else
            {
                Console.WriteLine("Некоретное число");
            }
        }
    }
        
    class Croupier
    {
        private Deck _deck;
        private Player _player;

        public Croupier()
        {
            _deck = new Deck();
            _player = new Player();
        }

        public void ShowPlayerCards()
        {
            Console.WriteLine("\nКарты игрока:");
            _player.ShowCards();
        }

        public void GiveCardsToPlayer(int count)
        {
            List<Card>cards = _deck.DrawCards(count);
            _player.TakeCards(cards);

        }



    }

    class Deck
    {
        private List<Card> _cards=new List<Card>();
        private Random _random=new Random();

        public Deck()
        {
            string[] suits = { "Пики", "Черви", "Крести", "Бубны" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    _cards.Add(new Card(suit, value));
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            int n = _cards.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
            }
        }

        public List<Card>DrawCards(int count)
        {
            List<Card> hand = new List<Card>();
            
            for (int i = 0; i < count && _cards.Count > 0; i++)
            {
                hand.Add(_cards[0]);
                _cards.RemoveAt(0);
            }
            return hand;
        }   
    }

    class Player
    {
         List<Card>_hand = new List<Card>();
        
        public void TakeCards(List<Card> cards)
        {
            _hand.AddRange(cards);
        }

        public void ShowCards()
        {
            if (_hand.Count == 0)
            {
                Console.WriteLine("Игрок не имеет карт");
            }
            else
            {
                foreach(Card card in _hand)
                {
                    Console.WriteLine(card);
                }
            }
        }

    }

    class Card
    {
       string _suit {  get; set; }
        string _value { get; set; }

        public Card(string suit, string value)
        {
            _suit = suit;
            _value = value;
        }

        public override string ToString()
        {
            return $"{_value} { _suit}";
        }
    }
}

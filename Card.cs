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

            if (int.TryParse(Console.ReadLine(), out int cardCount))
            {
                croupier.DealCards(cardCount);
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
        private Deck deck;
        private Player player;

        public Croupier()
        {
            deck = new Deck();
            player = new Player();
        }

        public void ShowPlayerCards()
        {
            Console.WriteLine("\nКарты игрока:");
            player.ShowCards();
        }

        public void DealCards(int count)
        {
            List<Card> cards = deck.DrawCards(count);
            player.TakeCards(cards);

        }



    }

    class Deck
    {
        private List<Card> cards = new List<Card>();
        private Random random = new Random();

        public Deck()
        {
            string[] suits = { "Пики", "Черви", "Крести", "Бубны" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    cards.Add(new Card(suit, value));
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            int totalCards = cards.Count;
            for (int i = totalCards - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);
                (cards[i], cards[randomIndex]) = (cards[randomIndex], cards[i]);
            }
        }

        public List<Card> DrawCards(int count)
        {
            List<Card> hand = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                if(cards.Count==0)
                    break;

                hand.Add(cards[0]);
                cards.RemoveAt(0);
            }
            return hand;
        }
    }

    class Player
    {
        List<Card> _cards = new List<Card>();

        public void TakeCards(List<Card> cards)
        {
            _cards.AddRange(cards);
        }

        public void ShowCards()
        {
            if (_cards.Count == 0)
            {
                Console.WriteLine("Игрок не имеет карт");
            }
            else
            {
                foreach (Card card in _cards)
                {
                    Console.WriteLine(card);
                }
            }
        }

    }

    class Card
    {
        public Card(string suit, string value)
        {
            Suit = suit;
            Value = value;
        }

        public string Suit { get; private set}
        public string Value { get; private set}

        public override string ToString()
        {
            return $"{Value} {Suit}";
        }
    }
}

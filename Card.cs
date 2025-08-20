using System;
using System.Collections.Generic;

namespace CARDs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Croupier croupier = new Croupier();
            croupier.TransferCard();
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

        public void DealCards(int count)
        {
            List<Card> cards = _deck.GiveCards(count);
            _player.TakeCards(cards);
        }

        public void TransferCard()
        {
            Console.WriteLine("Сколько карт выдать игроку?");

            if (int.TryParse(Console.ReadLine(), out int cardCount))
            {
                DealCards(cardCount);
                ShowPlayerCards();
            }
            else
            {
                Console.WriteLine("Некоретное число");
            }
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();
        private Random random = new Random();

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
            int totalCards = _cards.Count;

            for (int i = totalCards - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);
                (_cards[i], _cards[randomIndex]) = (_cards[randomIndex], _cards[i]);
            }
        }

        public List<Card> GiveCards(int count)
        {
            List<Card> hand = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                if (_cards.Count == 0)
                    break;

                hand.Add(_cards[0]);
                _cards.RemoveAt(0);
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

        public string Suit { get; private set; }
        public string Value { get; private set; }

        public override string ToString()
        {
            return $"{Value} {Suit}";
        }
    }
}
    


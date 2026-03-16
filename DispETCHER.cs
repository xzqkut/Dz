using System;
using System.Collections.Generic;

namespace Dispetcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dispetcher dispetcher = new Dispetcher();
            dispetcher.Work();
        }
    }

    class Extra
    {
        public static int RandomNumber(int minNumber, int maxNumber)
        {
            Random random = new Random();
            int number = random.Next(minNumber, maxNumber);
            return number;
        }
    }

    class Dispetcher
    {
        private List<Direction> _directions;
        private Train _train;

        private int _passengers;
        public Dispetcher()
        {
            _directions = new List<Direction>();
            _directions.Add(new Direction("Berlin", "Austria"));
            _directions.Add(new Direction("Berlin", "Italia"));
            _directions.Add(new Direction("Berlin", "Vengriya"));
        }

        public void Work()
        {
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("Диспетчер пассажиры купили билеты, требуется посадить их на места");

                Console.ReadLine();
                _passengers = Extra.RandomNumber(30, 600);

                Console.WriteLine($"Кол-во пассажиров {_passengers}");
                int index = Extra.RandomNumber(0, _directions.Count);
                Direction direction = _directions[index];

                _train = new Train(direction);

                _train.SeatPassengers(_passengers);
                _train.ShowInfo();
                _train.ShowWagons();

                Console.WriteLine("Для выхода напишите Q");

                string input = Console.ReadLine();

                if (input == "Q")
                {
                    isOpen = false;
                }

            }
        }
       
    }

    class Train
    {
        private const int SeatsPerWagon = 60;

        private List<Wagon> _wagons = new List<Wagon>();
        public Train(Direction direction)
        {
            Route = direction;
        }
        
        public int QuantityOfWagons =>_wagons.Count;
        public Direction Route {  get; private set; }

        public void SeatPassengers(int passenger)
        {
            while (passenger > 0)
            {
                Wagon wagon = new Wagon(_wagons.Count+1,SeatsPerWagon);
                int seated = wagon.FillWagon(passenger);
                passenger -= seated;
                _wagons.Add(wagon);
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Направление {Route}");
            Console.WriteLine($"Количество вагонов в рейсе {QuantityOfWagons}");
            Console.WriteLine(($"Всего мест:{GetTotalSeats()}"));
        }

        public void ShowWagons()
        {
            foreach(var wagon in _wagons)
            {
                Console.WriteLine($"Вагон {wagon.Number}|Свободно мест {wagon.FreeSeatsInWagon} из {wagon.QuantityOfSeatsInWagon}");
            }
        }

        public int GetTotalSeats()
        {
            int total = 0;
            
            foreach(var wagon in _wagons)
            {
                total += wagon.QuantityOfSeatsInWagon;
            }
            return total;
        }
    }

    class Wagon
    {

        public Wagon(int number,int numberOfSeatsInWagon)
        {
            FreeSeatsInWagon = numberOfSeatsInWagon;
            QuantityOfSeatsInWagon = numberOfSeatsInWagon;
            Number = number;
        }

        public int Number { get; private set; }
        public int QuantityOfSeatsInWagon { get; private set; }
        public int FreeSeatsInWagon { get; private set; }

        public int FillWagon(int passengers)
        {
            int seatedPassengers = Math.Min(passengers, FreeSeatsInWagon);
            FreeSeatsInWagon -= seatedPassengers;
            return seatedPassengers;
        }
    }

    class Direction
    {
        public Direction(string departurePoint, string arrivalPoint)
        {
            DeparturePoint = departurePoint;
            ArrivalPoint = arrivalPoint;
        }

        public string DeparturePoint { get; private set; }
        public string ArrivalPoint { get; private set; }

        public override string ToString()
        {
            return DeparturePoint + "-" + ArrivalPoint;
        }
    }
}


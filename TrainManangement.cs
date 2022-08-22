using System;
using System.Collections.Generic;

namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TrainManager trainManager = new TrainManager(10);
            trainManager.Work();
        }
    }

    class StatusBar
    {
        public string Text { get; private set; }
        public int PositionY { get; private set; }

        public StatusBar(int topOffset)
        {
            PositionY = topOffset;
        }

        public void Display()
        {
            int previousCursorPositionX = Console.CursorLeft;
            int previousCursorPositionY = Console.CursorTop;

            for (int positionX = Console.WindowWidth; positionX >= 0; positionX--)
            {
                Console.SetCursorPosition(positionX, PositionY);
                Console.Write(' ');
            }

            Console.SetCursorPosition(0, PositionY);
            Console.Write(Text);

            Console.SetCursorPosition(previousCursorPositionX, previousCursorPositionY);
        }

        public void UpdateText(string text)
        {
            Text = text;
            Display();
        }
    }

    class TrainManager
    {
        private List<Train> _trainsDispatched;
        private Train _currentTrain;
        private List<Carriage> _availableCarriages;
        private StatusBar _statusBar;
        private int _statusBarPositionY = 0;
        private int _mainTextOffsetY = 2;

        public TrainManager(int carriageCount)
        {
            _trainsDispatched = new List<Train>();
            _availableCarriages = new List<Carriage>();
            _statusBar = new StatusBar(_statusBarPositionY);

            AddCarriages(carriageCount);
        }

        public void AddCarriages(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _availableCarriages.Add(new Carriage());
            }
        }

        public void Work()
        {
            bool isWorking = true;

            while (isWorking)
            {
                ClearConsole();

                if (_currentTrain != null)
                    _trainsDispatched.Add(_currentTrain);

                _currentTrain = new Train(ReadDirection());
                _currentTrain.SellTickets();
                WaitKey();

                string statusBarText = _statusBar.Text;

                while (_currentTrain.HasEnoughPassengerCapacity == false)
                {
                    ClearConsole();

                    _statusBar.UpdateText(statusBarText + $"Carriages: {_currentTrain.CarriageCount} | Capacity: {_currentTrain.PassengerCapacity}/{_currentTrain.TicketsBought}");


                    for (int i = 0; i < _availableCarriages.Count; i++)
                    {
                        Carriage carriage = _availableCarriages[i];
                        Console.WriteLine($"{i} | Capacity: {carriage.PassengerCapacity}");
                    }

                    Console.Write("Index of carriage to attach (other number to buy new carriage): ");
                    int newCarriageIndex = ReadInt();

                    if (newCarriageIndex >= 0 && newCarriageIndex < _availableCarriages.Count)
                    {
                        _currentTrain.AddCarriage(_availableCarriages[newCarriageIndex]);
                        _availableCarriages.RemoveAt(newCarriageIndex);
                    }
                    else
                    {
                        AddCarriages(1);
                    }
                }

                Console.WriteLine("Train now has enough passenger capacity.");
                Console.WriteLine("Press [Esc] to exit, press any other key to prepare another train]");

                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    isWorking = false;
            }
        }

        public Direction ReadDirection()
        {
            string directionFormat = "Train from {0} to {1} | ";
            _statusBar.UpdateText(string.Format(directionFormat, "...", "..."));

            Console.Write("Departure City: ");
            string departureCity = Console.ReadLine();
            _statusBar.UpdateText(string.Format(directionFormat, departureCity, "..."));

            Console.Write("Destination City: ");
            string destinationCity = Console.ReadLine();
            _statusBar.UpdateText(string.Format(directionFormat, departureCity, destinationCity));

            return new Direction(departureCity, destinationCity);
        }

        private void WaitKey()
        {
            Console.WriteLine("[Press any key to continue]");
            Console.ReadKey(true);
        }

        private void ClearConsole()
        {
            Console.Clear();
            Console.SetCursorPosition(0, _statusBar.PositionY + _mainTextOffsetY);
        }

        private int ReadInt()
        {
            int inputtedInteger;

            while (int.TryParse(Console.ReadLine(), out inputtedInteger) == false) { }

            return inputtedInteger;
        }

    }

    class Train
    {
        private List<Carriage> _carriages = new List<Carriage>();
        private Direction _direction;
        private Random _random;
        private int _minTicketsBought = 200;
        private int _maxTickestBought = 500;

        public int TicketsBought { get; private set; }
        public int CarriageCount { get {return _carriages.Count; } }
        public int PassengerCapacity { get; private set; }
        public bool HasEnoughPassengerCapacity { get; private set; }

        public Train(Direction direction)
        {
            _random = new Random();
            _direction = direction;
        }

        public void AddCarriage(Carriage carriage)
        {
            _carriages.Add(carriage);
            PassengerCapacity += carriage.PassengerCapacity;
            HasEnoughPassengerCapacity = PassengerCapacity >= TicketsBought;
        }

        public void SellTickets()
        {
            TicketsBought = _random.Next(_minTicketsBought, _maxTickestBought);
            Console.WriteLine("Tickets Bought: " + TicketsBought);
        }
    }

    class Carriage
    {
        private Random _random;
        private int _minCarriagePassengerCapacity = 50;
        private int _maxCarriagePassengerCapacity = 95;

        public int PassengerCapacity { get; private set; }

        public Carriage()
        {
            _random = new Random();
            PassengerCapacity = _random.Next(_minCarriagePassengerCapacity, _maxCarriagePassengerCapacity);
        }
    }

    class Direction
    {
        public string DepartureCity { get; private set; }
        public string DestinationCity { get; private set; }

        public Direction(string departureCity, string arrivalCity)
        {
            DepartureCity = departureCity;
            DestinationCity = arrivalCity;
        }
    }
}

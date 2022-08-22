using System;
using System.Collections.Generic;

namespace TrainManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainManager trainManager = new TrainManager(new List<City>
                {
                    new City("Moscow", 90, 12635000),
                    new City("Saint Petersburg", 67, 11920000),
                    new City("Yaroslavl", 54, 597161)
                },
                10
            );
            trainManager.Work();
        }
    }

    class TrainManager
    {
        private List<Train> _trainsSent;
        private Train _currentTrain;
        private List<City> _availableCities;
        private List<Carriage> _availableCarriages;

        public TrainManager(List<City> availableCities, int carriageCount)
        {
            Random random = new Random();
            int minCarriagePassengerCapacity = 50;
            int maxCarriagePassengerCapacity = 95;

            _trainsSent = new List<Train>();
            _availableCities = availableCities;
            _availableCarriages = new List<Carriage>();

            for (int i = 0; i < carriageCount; i++)
            {
                _availableCarriages.Add(new Carriage(random.Next(minCarriagePassengerCapacity, maxCarriagePassengerCapacity)));
            }
        }

        public void StartPreparingNewTrain(City departureCity, City arrivalCity)
        {
            _trainsSent.Add(_currentTrain);
            _currentTrain = new Train(departureCity, arrivalCity);
        }

        public void DisplayListWithHighlight(List<string> list, int highlightIndex = -1)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string element = list[i];

                if (i == highlightIndex)
                {
                    Console.WriteLine($"> {element} <");
                }
                else
                {
                    Console.WriteLine(element);
                }
            }
        }

        public Carriage GetCarriageFromUser(string prompt)
        {
            int selectedCarriageIndex = 0;
            Carriage selectedCarriage = _availableCarriages[selectedCarriageIndex];
            bool selectionMade = false;
            List<string> carriageLabels = new List<string>();

            foreach (Carriage carriage in _availableCarriages)
            {
                carriageLabels.Add($"Capacity: {carriage.PassengerCapacity}");
            }

            while (selectionMade == false)
            {
                Console.Clear();
                Console.Write(prompt);
                DisplayListWithHighlight(carriageLabels, selectedCarriageIndex);

                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                switch (pressedKey)
                {
                    case ConsoleKey.DownArrow:
                        if (selectedCarriageIndex < _availableCarriages.Count - 1)
                        {
                            selectedCarriageIndex++;
                            selectedCarriage = _availableCarriages[selectedCarriageIndex];
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (selectedCarriageIndex >= 1)
                        {
                            selectedCarriageIndex--;
                            selectedCarriage = _availableCarriages[selectedCarriageIndex];
                        }
                        break;
                    case ConsoleKey.Enter:
                        selectionMade = true;
                        break;
                }
            }

            return selectedCarriage;
        }

        public City GetCityFromUser(string prompt)
        {
            int selectedCityIndex = 0;
            City selectedCity = _availableCities[selectedCityIndex];
            bool selectionMade = false;
            List<string> cityNames = new List<string>();

            foreach (City city in _availableCities)
            {
                cityNames.Add(city.Name);
            }

            while (selectionMade == false)
            {
                Console.Clear();

                Console.WriteLine(prompt);
                DisplayListWithHighlight(cityNames, selectedCityIndex);

                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                switch (pressedKey)
                {
                    case ConsoleKey.DownArrow:
                        if (selectedCityIndex < _availableCities.Count - 1)
                        {
                            selectedCityIndex++;
                            selectedCity = _availableCities[selectedCityIndex];
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (selectedCityIndex >= 1)
                        {
                            selectedCityIndex--;
                            selectedCity = _availableCities[selectedCityIndex];
                        }
                        break;
                    case ConsoleKey.I:
                        Console.Clear();
                        selectedCity.ShowInfo();
                        Console.WriteLine();
                        WaitKey();
                        break;
                    case ConsoleKey.Enter:
                        selectionMade = true;
                        break;
                }
            }

            return selectedCity;
        }

        public void WaitKey()
        {
            Console.WriteLine("[Press any key to continue]");
            Console.ReadKey(true);
        }

        public void Work()
        {
            bool isApplicationRunning = true;
            
            while (isApplicationRunning)
            {
                City departureCity = GetCityFromUser("Select departure city:");
                City arrivalCity = GetCityFromUser("Select arrival city: ");

                _currentTrain = new Train(departureCity, arrivalCity);

                _currentTrain.SellTickets();
                Console.WriteLine($"{_currentTrain.TicketsBought} tickets were bought for your train");
                WaitKey();

                while (_currentTrain.HasEnoughCapacity == false)
                {
                    Console.Clear();
                    Carriage selectedCarriage = GetCarriageFromUser("Select carriages for your train:");
                    _availableCarriages.Remove(selectedCarriage);
                    _currentTrain.AttachCarriage(selectedCarriage);
                }
            }
        }
    }

    class City
    {
        public string Name { get; private set; }
        public int Attractiveness { get; private set; }
        public int Population { get; private set; }

        public City(string name, int attractiveness, int population)
        {
            Name = name;
            Attractiveness = attractiveness;
            Population = population;
        }

        public void ShowInfo()
        {
            Console.Write($"Name: {Name}\nAttractiveness Rating: {Attractiveness}%\nPopulation: {Population}");
        }
    }

    class Carriage
    {
        public int PassengerCapacity { get; private set; }

        public Carriage(int passengerCapacity)
        {
            PassengerCapacity = passengerCapacity;
        }
    }

    class Train
    {
        private List<Carriage> _carriages;
        private Random _random;

        public int PassengerCapacity { get; private set; }
        public int TicketsBought { get; private set; }
        public City DepartureCity { get; private set; }
        public City ArrivalCity { get; private set; }
        public bool HasEnoughCapacity { get; private set; }

        public Train(City departureCity, City arrivalCity)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            _random = new Random();
            _carriages = new List<Carriage>();
        }

        public void AttachCarriage(Carriage carriage)
        {
            _carriages.Add(carriage);
            PassengerCapacity += carriage.PassengerCapacity;
            HasEnoughCapacity = PassengerCapacity >= TicketsBought;
        }

        public void SellTickets()
        {
            int minAttractivenessModifier = 90;
            int maxAttractivenessModifier = 110;

            int departingPassengers = DepartureCity.Population * ArrivalCity.Attractiveness;
            int arrivingPassengers = ArrivalCity.Population * DepartureCity.Attractiveness;
            int attractivenessModifier = _random.Next(minAttractivenessModifier, maxAttractivenessModifier);
            TicketsBought = (departingPassengers + arrivingPassengers) * attractivenessModifier / 100;
        }
    }
}

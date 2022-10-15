namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new RepairShop(new List<Part>
            {
                new Part("Radiator", 100, 30),
                new Part("Wheel", 400, 60),
                new Part("Windshield", 1000, 100),
                new Part("Steering Wheel", 500, 10)
            }, 100).Work();
        }
    }

    static class UserUtils
    {
        public static void WaitKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
        }

        public static int ReadInt(int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int outputtedInteger;

            while (int.TryParse(Console.ReadLine(), out outputtedInteger) == false || outputtedInteger < minValue || outputtedInteger > maxValue) ;

            return outputtedInteger;
        }
    }

    class RepairShop
    {
        private Storage _storage;
        private List<Part> _allParts;
        private Random _random;
        private Car _currentCar;
        private const ConsoleKey _interactionKey1 = ConsoleKey.D1;
        private const ConsoleKey _interactionKey2 = ConsoleKey.D2;
        private const ConsoleKey _exitKey = ConsoleKey.Q;

        public int Money { get; private set; }
        public int IncorrectRepairFine { get; private set; }

        public RepairShop(List<Part> allParts, int refusalCompensation)
        {
            _random = new Random();
            _storage = new Storage();
            _allParts = allParts;
            IncorrectRepairFine = refusalCompensation;

            foreach (Part part in _allParts)
            {
                _storage.AddPart(part);
            }
        }

        public void Work()
        {
            bool isWorking = true;

            do
            {
                ServeCar();
                Console.Clear();
                Console.WriteLine($"Press [{_exitKey}] to exit, press any other key to continue");

                isWorking = Money >= 0 && Console.ReadKey(true).Key != _exitKey;
            } while (isWorking);

            Console.Clear();

            if (Money <= 0)
            {
                Console.Write("You became bankrupt");

                if (Money < 0)
                    Console.Write($" (Debt: {-Money})");

                Console.WriteLine();
            }
            else
                Console.WriteLine("Game exited");
        }

        private void ServeCar()
        {
            ConsoleKey userInput;
            _currentCar = new Car(GetRandomPart());

            do
            {
                Console.Clear();
                Console.WriteLine($"Your balance: {Money}");
                _currentCar.ShowInfo();
                Console.WriteLine($"Total Repair Cost: {_currentCar.BrokenPart.TotalCost}");


                Console.WriteLine($"[{_interactionKey1}] Attempt repair");
                Console.WriteLine($"[{_interactionKey2}] Visit storage");

                userInput = Console.ReadKey(true).Key;
                Console.Clear();

                switch (userInput)
                {
                    case _interactionKey1:
                        TryRepair();
                        break;
                    case _interactionKey2:
                        _storage.ShowParts();
                        break;
                }

                UserUtils.WaitKey();
            } while (userInput != ConsoleKey.D1);
        }

        private void TryRepair()
        {
            Console.WriteLine("Select part to replace: ");
            _storage.ShowParts(true);

            int replacementPartIndex = UserUtils.ReadInt(0, _storage.PartCount);
            Part replacementPart;
            _storage.TryGetPartByIndex(replacementPartIndex, out replacementPart);

            if (replacementPart == _currentCar.BrokenPart)
            {
                Console.WriteLine("Replacement succesful");
                Money += replacementPart.TotalCost;
            }
            else
            {
                Console.WriteLine("Replacement failed! Incorrect part selected");
                PayFine();
            }   
        }

        private void ReplacePart(Part part)
        {
            _storage.TryRemovePart(part);
            Money += part.TotalCost;
        }

        private void PayFine()
        {
            Money -= IncorrectRepairFine;
        }

        private Part GetRandomPart()
        {
            return _allParts[_random.Next(_allParts.Count)];
        }
    }

    class Car
    {
        public Part BrokenPart { get; private set; }

        public Car(Part brokenPart)
        {
            BrokenPart = brokenPart;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"The car's {BrokenPart.Name} is broken");
        }
    }

    class Part
    {
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public int InstallationCost { get; private set; }
        public int TotalCost => Cost + InstallationCost;

        public Part(string name, int cost, int serviceCharge)
        {
            Name = name;
            Cost = cost;
            InstallationCost = serviceCharge;
        }
    }

    class Storage
    {
        private Dictionary<Part, int> _parts;

        public int PartCount => _parts.Count;

        public Storage()
        {
            _parts = new Dictionary<Part, int>();
        }

        public bool HasPart(Part part, int amount = 1)
        {
            return _parts.ContainsKey(part) && _parts[part] >= amount;
        }

        public void AddPart(Part part, int amount = 1)
        {
            if (_parts.ContainsKey(part))
                _parts[part] += amount;
            else
                _parts[part] = amount;
        }

        public bool TryRemovePart(Part part, int amount = 1)
        {
            if (_parts.ContainsKey(part) && _parts[part] >= amount)
            {
                _parts[part] -= amount;

                if (_parts[part] == 0)
                    _parts.Remove(part);

                return true;

            }
            else
            {
                return false;
            }
        }

        public void ShowParts(bool showIndices = false)
        {
            if (_parts.Count > 0)
            {
                for (int i = 0; i < _parts.Count; i++)
                {
                    var part = _parts.ElementAt(i);

                    if (showIndices)
                        Console.Write($"[{i}] ");

                    Console.WriteLine($"{part.Key.Name} x{part.Value}");
                }
            }
            else
            {
                Console.WriteLine("Storage empty");
            }
        }

        public bool TryGetPartByIndex(int index, out Part part)
        {
            if (index >= 0 && index < _parts.Count)
            {
                part = _parts.ElementAt(index).Key;
                return true;
            } else
            {
                part = null;
                return false;
            }
        }
    }
}

namespace ComputerClub
{
    internal class Program
    {
        public static void ReadInt(out int outputInt)
        {
            while (int.TryParse(Console.ReadLine(), out outputInt) == false) { }
        }

        static void Main(string[] args)
        {
            ComputerClub club = new ComputerClub(10);
            int startingUserCount = 90;

            for (int i = 0; i < startingUserCount; i++)
            {
                club.EnqueueRandomGeneratedUser();
            }

            club.ServeQueue();
        }
    }

    class ComputerClub
    {
        private int _accountBalance = 0;
        private List<Computer> _computers;
        private Queue<User> _users;
        private Random _random;
        public string Summary {
            get
            {
                string summary = $"Computer Club Balance: {_accountBalance}\n";

                for (int i = 0; i < _computers.Count; i++)
                {
                    summary += i + " " + _computers[i].Summary + '\n';
                }

                return summary;
            }
        }

        public ComputerClub (int computerCount, int minPricePerMinute = 5, int maxPricePerMinute = 8)
        {
            _computers = new List<Computer>();
            _users = new Queue<User>();
            _random = new Random();

            for (int i = 0; i < computerCount; i++)
            {
                int pricePerMinute = _random.Next(minPricePerMinute, maxPricePerMinute + 1);
                _computers.Add(new Computer(pricePerMinute));
            }
        }

        public ComputerClub()
        {
            _computers = new List<Computer>();
            _users = new Queue<User>();
            _random = new Random();
        }

        public void EnqueueRandomGeneratedUser(int minMoney = 100, int maxMoney = 250, int minMinutes = 10, int maxMinutes = 120)
        {

            int money = _random.Next(minMoney, maxMoney);
            int minutes = _random.Next(minMinutes, maxMinutes);
            _users.Enqueue(new User(money, minutes));
        }

        public void EnqueueUser(User user)
        {
            _users.Enqueue(user);
        }

        public void UpdateComputers()
        {
            foreach (Computer computer in _computers)
            {
                computer.UpdateMinutes();
            }
        }

        public void ServeQueue()
        {
            while (_users.Count > 0)
            {
                Console.WriteLine("Club summary: ");
                Console.Write(Summary);

                User user = _users.Dequeue();
                Console.WriteLine($"Next User In Queue: wants a computer for {user.DesiredMinutes}min");

                Console.WriteLine("Which computer to offer to user? ");
                int offeredComputerNumber;
                Program.ReadInt(out offeredComputerNumber);

                if (offeredComputerNumber >= 0 && offeredComputerNumber < _computers.Count) {
                    Computer offeredComptuer = _computers[offeredComputerNumber];

                    if (offeredComptuer.IsOccupied)
                    {
                        Console.WriteLine("The user stared at you in shock because you pointed them to a computer which is already in use. The user left");
                    } 
                    else
                    {
                        if (user.BillAndCheckSolvency(offeredComptuer))
                        {
                            _accountBalance += user.PayBill();
                            offeredComptuer.Occupy(user);
                            Console.WriteLine("The user took this computer.");
                        }
                        else
                        {
                            Console.WriteLine("The user did not have enough money to rent this computer.");
                        }
                    }
                } 
                else
                {
                    Console.WriteLine("You pointed the user to a computer that does not exist and almost caused a time-space rupture. The user left.");
                }

                Console.WriteLine("[Press any key to continue]");
                Console.ReadKey(true);
                Console.Clear();

                UpdateComputers();
            }
        }
    }

    class Computer
    {
        private User _user;
        public int MinutesLeft { get; private set; }
        public int PricePerMinute { get; private set; }

        public bool IsOccupied { get { return MinutesLeft > 0; } }
        public string Summary
        {
            get
            {
                string summary = $"Rate: {PricePerMinute}$/min | ";

                if (IsOccupied)
                    summary += $"Occupied (Time left: {MinutesLeft}min)";
                else
                    summary += "Not occupied";

                return summary;
            }
        }

        public Computer(int pricePerMinute)
        {
            PricePerMinute = pricePerMinute;
        }

        public void Occupy(User user)
        {
            _user = user;
            MinutesLeft = user.DesiredMinutes;
        }

        public void Free()
        {
            _user = null;
        }

        public void UpdateMinutes(int minutesPassed = 1)
        {
            MinutesLeft -= minutesPassed;

            if (MinutesLeft == 0)
                Free();
        }
     }

    class User
    {
        private int _accountBalance;
        public int DesiredMinutes { get; private set; }
        private int _paymentTotal;

        public User(int accountBalance, int desiredStayMinutes)
        {
            _accountBalance = accountBalance;
            DesiredMinutes = desiredStayMinutes;
        }

        public bool BillAndCheckSolvency(Computer computer)
        {
            _paymentTotal = computer.PricePerMinute * DesiredMinutes;

            if (_accountBalance - _paymentTotal >= 0)
            {
                return true;
            }
            else
            {
                _paymentTotal = 0;
                return false;
            }
        }

        public int PayBill()
        {
            _accountBalance -= _paymentTotal;
            return _paymentTotal;
        }
    }
}

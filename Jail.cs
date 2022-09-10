namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Jail().Work();
        }
    }

    static class UserUtils
    {
        public static int ReadInt(int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int inputtedValue;

            while (int.TryParse(Console.ReadLine(), out inputtedValue) == false || inputtedValue < minValue || inputtedValue > maxValue) { }

            return inputtedValue;
        }

        public static void WaitKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
        }
    }

    class Jail
    {
        private List<Criminal> _criminals = new List<Criminal>();

        private Crime ReadCrime()
        {
            Array crimes = Enum.GetValues(typeof(Crime));

            for (int i = 0; i < crimes.Length; i++) { 
                Console.WriteLine(i + " " + (Crime)i);
            }

            Console.WriteLine("Enter crime index: ");
            return (Crime) crimes.GetValue(UserUtils.ReadInt(0, crimes.Length));
        }

        private Criminal CreateCriminal()
        {
            Console.WriteLine("Enter criminal data");
            Console.Write("Name: ");
            string criminalName = Console.ReadLine();

            Console.Write("Last name: ");
            string criminalLastName = Console.ReadLine();

            Crime crime = ReadCrime();
            return new Criminal(criminalName, criminalLastName, crime);
        }

        private int ReadCriminalIndex()
        {
            ShowCriminals(false, true);
            int criminalIndex;
            Console.Write("Criminal index: ");

            while (int.TryParse(Console.ReadLine(), out criminalIndex) == false || criminalIndex < 0 || criminalIndex >= _criminals.Count()) { }

            return criminalIndex;
        }
             
        public void ArrestCriminal(Criminal criminal)
        {
            _criminals.Add(criminal);
        }

        public void FreeCriminal(int index)
        {
            _criminals.RemoveAt(index);
        }

        public void DeclareAmnesty(Crime crime)
        {
            _criminals.RemoveAll(criminal => criminal.Crime == crime);
        }

        public void ShowCriminals(bool waitKey = true, bool showIndices = false)
        {
            if (_criminals.Count > 0)
            {
                foreach (Criminal criminal in _criminals)
                {
                    if (showIndices)
                    {
                        Console.Write(_criminals.IndexOf(criminal));
                    }

                    Console.WriteLine($"{criminal.Name} {criminal.LastName} | {criminal.Crime}");
                }
            } else
            {
                Console.WriteLine("No criminals");
            }

            if (waitKey)
            {
                UserUtils.WaitKey();
            }
        }

        public void Work()
        {
            const ConsoleKey arrestKey = ConsoleKey.D1;
            const ConsoleKey freeKey = ConsoleKey.D2;
            const ConsoleKey amnestyKey = ConsoleKey.D3;
            const ConsoleKey criminalListKey = ConsoleKey.D4;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();

                Console.WriteLine("Jail Database");
                Console.WriteLine($"[{arrestKey}] Arrest Criminal");
                Console.WriteLine($"[{freeKey}] Free Criminal");
                Console.WriteLine($"[{amnestyKey}] Declare Amnesty");
                Console.WriteLine($"[{criminalListKey}] Show Criminals");

                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                switch (pressedKey)
                {
                    case arrestKey:
                        ArrestCriminal(CreateCriminal());
                        break;
                    case freeKey:
                        FreeCriminal(ReadCriminalIndex());
                        break;
                    case amnestyKey:
                        DeclareAmnesty(ReadCrime());
                        break;
                    case criminalListKey:
                        ShowCriminals();
                        break;
                }
            }
        }
    }

    enum Crime
    {
        AntiGovernment, Murder, Theft, Bribe
    }

    class Criminal
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public Crime Crime { get; private set; }

        public Criminal(string name, string lastName, Crime crime)
        {
            Name = name;
            LastName = lastName;
            Crime = crime;
        }
    }
}

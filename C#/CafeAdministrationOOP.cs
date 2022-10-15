namespace CafeAdministratorOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Table[] tables = {
                new Table(1, 2),
                new Table(2, 4),
                new Table(3, 4),
                new Table(4, 6),
                new Table(5, 5),
            };

            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.Clear();

                foreach (Table table in tables)
                {
                    Console.WriteLine(table.Summary());
                }

                Console.WriteLine();
                Console.WriteLine("Cafe Administration");
                Console.WriteLine("[1] Book table");
                Console.WriteLine("[2] Release booking");
                Console.WriteLine("[<] Exit");

                ConsoleKey userCommand = Console.ReadKey(true).Key;
                Console.WriteLine();

                switch (userCommand)
                {
                    case ConsoleKey.D1:
                        BookTable(tables);
                        break;
                    case ConsoleKey.D2:
                        CancelBooking(tables);
                        break;
                }
            }
        }

        static void WaitKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
        }

        static void GetTableAndPlaceCount(Table[] tables, out Table table, out int placeCount)
        {
            Console.WriteLine("Table Booking");
            Console.Write("Table Number: ");
            int tableNumber = Convert.ToInt32(Console.ReadLine());
            table = tables[tableNumber - 1];

            Console.Write("Place Amount: ");
            placeCount = Convert.ToInt32(Console.ReadLine());
        }

        static void BookTable(Table[] tables)
        {
            int placeCount;
            Table table;
            GetTableAndPlaceCount(tables, out table, out placeCount);

            if (table.Book(placeCount))
                Console.WriteLine("Booking complete");
            else
                Console.WriteLine("Booking failed");

            WaitKey();
        }

        static void CancelBooking(Table[] tables)
        {
            int placeCount;
            Table table;
            GetTableAndPlaceCount(tables, out table, out placeCount);

            if (table.CancelBooking(placeCount))
                Console.WriteLine("Cancellation complete");
            else
                Console.WriteLine("Cancellation failed");

            WaitKey();
        }
    }

    class Table
    {
        private int _totalPlaces;
        private int _freePlaces;
        private int _number;

        public Table(int number, int places)
        {
            _number = number;
            _totalPlaces = places;
            _freePlaces = _totalPlaces;
        }

        public string Summary()
        {
            return $"Table {_number} - {_freePlaces}/{_totalPlaces} places available";
        }

        public bool Book(int placesToBook)
        {
            bool canReserve = _freePlaces >= placesToBook;

            if (canReserve)
                _freePlaces -= placesToBook;

            return canReserve;
        }

        public bool CancelBooking(int placesToCancel)
        {
            bool canCancel = _freePlaces + placesToCancel <= _totalPlaces;

            if (canCancel)
                _freePlaces += placesToCancel;

            return canCancel;
        }
    }
}

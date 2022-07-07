bool appOpen = true;
int availableTablesMenuX = 35;
int mainMenuRows = 3;

Console.Write("How many tables do you have? ");
int tableCount = Convert.ToInt32(Console.ReadLine());

int[] placesAtTables = new int[tableCount];

for (int i = 0; i < tableCount; i++)
{
    Console.Write($"Sitting spaces at table {i}: ");
    placesAtTables[i] = Convert.ToInt32(Console.ReadLine());
}

while (appOpen)
{
    Console.Clear();

    Console.SetCursorPosition(0, 0);
    Console.WriteLine("==MAIN MENU==");
    Console.WriteLine("[1] Book a table");
    Console.WriteLine("[2] Exit");

    Console.SetCursorPosition(availableTablesMenuX, 0);
    Console.WriteLine("==AVAILABLE TABLES==");
    for (int i = 0; i < placesAtTables.Length; i++) 
    {
        Console.SetCursorPosition(availableTablesMenuX, i+1);
        int placesAtTable = placesAtTables[i];
        if (placesAtTable > 0)
            Console.WriteLine($"Table {i}: {placesAtTable}");
    }

    Console.SetCursorPosition(0, mainMenuRows);
    Console.Write("[Press a Main Menu action key]");
    char choice = Console.ReadKey(true).KeyChar;

    switch (choice)
    {
        case '1':
            Console.SetCursorPosition(0, mainMenuRows + 2);
            Console.WriteLine("==TABLE BOOKING==");
            Console.Write("Table Number: ");
            int tableNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Place Count: ");
            int bookingPlaceCount = Convert.ToInt32(Console.ReadLine());

            int placesAtDesiredTable = placesAtTables[tableNumber];
            if (bookingPlaceCount > placesAtDesiredTable || bookingPlaceCount < 0)
                Console.WriteLine("Operation failed: desired place count too large or below zero");
            else
                placesAtTables[tableNumber] -= bookingPlaceCount;

            Console.WriteLine("[Press any key to Continue]");
            Console.ReadKey();
            break;
        case '2':
            appOpen = false;
            break;
        default:
            Console.WriteLine("[Invalid menu action]");
            Console.Read();
            break;
    }

}

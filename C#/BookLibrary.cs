int shelveWidth = 10;
int shelveHeight = 10;
string[,] books = new string[shelveWidth, shelveHeight];

bool runApp = true;

while (runApp) {
    Console.Clear();
    Console.WriteLine("== LIBRARY == [X] Close");
    Console.WriteLine("[1] Get book by coordinates");
    Console.WriteLine("[2] Find book by title");
    Console.WriteLine("[3] Add book");
    char choice = Console.ReadKey(true).KeyChar;

    Console.Clear();

    switch (choice) {
        case '1':
            Console.Write("X: ");
            int searchBookX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Y: ");
            int searchBookY = Convert.ToInt32(Console.ReadLine());

            string book;
            if (searchBookX < books.GetLength(0) && searchBookY < books.GetLength(1))
            {
                book = books[searchBookX, searchBookY];
                Console.WriteLine(book);
            }
            else
            {
                Console.WriteLine("Invalid coordinates");
            }

            break;
        case '2':
            Console.WriteLine("Title: ");
            string searchBookTitle = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < books.GetLength(0); i++) {
                for (int j = 0; j < books.GetLength(1); j++) {
                    if (books[i, j] == searchBookTitle)
                    {
                        found = true;
                        Console.WriteLine($"X: {i}; Y: {j}");
                    }
                }
            }

            if (found == false)
                Console.WriteLine("Not found");

            break;
        case '3':
            Console.Write("X: ");
            int newBookX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Y: ");
            int newBookY = Convert.ToInt32(Console.ReadLine());
            Console.Write("Title: ");
            string newBookTitle = Console.ReadLine();

            if (newBookX < books.GetLength(0) && newBookY < books.GetLength(1))
            {
                books[newBookX, newBookY] = newBookTitle;
                Console.WriteLine("Added successfully");
            }
            else
                Console.WriteLine("Invalid coordinates");

            break;
        case 'x':
            runApp = false;
            break;
      
    }

    Console.WriteLine("[Press any key to continue]");
    Console.ReadKey(true);
}

int userChoice = 0;
string username = "admin";
string password = "adminadmin1234";
bool isDarkScheme = true;

while (userChoice != 5)
{
    Console.Clear();
    Console.WriteLine($"Hello, {username}, your password is {password}");
    Console.WriteLine("[1] Toggle Color Scheme");
    Console.WriteLine("[2] Change Username");
    Console.WriteLine("[3] Change Password");
    Console.WriteLine("[4] Order Pizza");
    Console.WriteLine("[5] Logout");
    userChoice = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    switch (userChoice) {
        case 1:
            if (isDarkScheme)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            isDarkScheme = !isDarkScheme;

            break;
        case 2:
            Console.Write("Password: ");
            string userInputPassword = Console.ReadLine();
            Console.Write("New Username: ");
            string newUsername = Console.ReadLine();

            if (userInputPassword == password)
            {
                username = newUsername;
                Console.WriteLine("Username Changed");
            }
            else {
                Console.WriteLine("Incorrect Password.");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            break;
        case 3:

            Console.Write("Old Password: ");
            string oldPassword = Console.ReadLine();

            Console.Write("New Password: ");
            string newPassword = Console.ReadLine();

            if (oldPassword == password)
            {
                password = newPassword;
                Console.WriteLine("Password changed");
            }
            else {
                Console.WriteLine("Incorrect password.");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            break;
        case 4:
            Console.Write("What Pizza would you like?");
            string flavor = Console.ReadLine();

            Console.Write("What size (small, medium, large)? ");
            string size = Console.ReadLine();

            if (size == "small" || size == "medium" || size == "large")
                Console.WriteLine($"Ordered a {flavor} pizza of size {size}");
            else
                Console.WriteLine("Invalid size.");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            break;
    }
}

Console.WriteLine("Logged out");

Console.WriteLine("Please set a password");
Console.Write("Password: ");
string password = Console.ReadLine();
Console.WriteLine("Password succesfully set! Press any key to continue.");
Console.ReadKey(true);
while (true)
{
    Console.Clear();

    Console.WriteLine("Please enter your new password.");
    Console.Write("Password: ");
    string enteredPassword = Console.ReadLine();
    Console.Clear();
    bool isPasswordCorrect = enteredPassword == password;
    if (isPasswordCorrect)
    {
        Console.WriteLine("Login successful!");
        break;
    }
    else
    {
        Console.WriteLine("Login failed: incorrect password.");
        Thread.Sleep(2000);
    }
}

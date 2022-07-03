using System.Net;

Console.Write("Starting amount of RUB: ");
float rubAmount = Convert.ToSingle(Console.ReadLine());

Console.Write("Starting amount of USD: ");
float usdAmount = Convert.ToSingle(Console.ReadLine());

float usdToRub = 70f;
float rubToUsd = 1f/usdToRub;

Console.WriteLine($"You have {rubAmount}₽ and {usdAmount}$");

while (true)
{

    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. Convert ₽ into $");
    Console.WriteLine("2. Convert $ into ₽");
    int choice = Convert.ToInt32(Console.ReadLine());

    Console.Clear();

    float currencyAmount = 0f;
    switch (choice)
    {
        case 1:
            Console.Write($"How much ₽ would you like to convert (you have: {rubAmount})? ");
            currencyAmount = Convert.ToSingle(Console.ReadLine());

            rubAmount -= currencyAmount;
            usdAmount += currencyAmount * rubToUsd;
            break;
        case 2:
            Console.Write($"How much $ would you like to convert (you have: {usdAmount})? ");
            currencyAmount = Convert.ToSingle(Console.ReadLine());

            usdAmount -= currencyAmount;
            rubAmount += currencyAmount * usdToRub;
            break;
    }
    Console.Clear();
    Console.WriteLine($"After the conversion, you have {rubAmount}₽ and {usdAmount}$");
    Console.WriteLine("Press any key to continue");
    Console.ReadKey(true);
}

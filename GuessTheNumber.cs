Random random = new Random();

const int minCorrectNumber = 1;
const int maxCorrectNumber = 100;
int correctNumber = random.Next(minCorrectNumber, maxCorrectNumber + 1);

int userGuess = 0;
int attempts = 1;
const int maxAttempts = 10;
Console.WriteLine($"You have {maxAttempts} attempts to guess a number between {minCorrectNumber} and {maxCorrectNumber}. Good luck!");
Console.WriteLine("Press any key to start");
Console.WriteLine(correctNumber);
Console.ReadKey();
while (userGuess != correctNumber && attempts <= maxAttempts)
{
    Console.Clear();
    Console.Write($"Attempt {attempts}: ");
    userGuess = Convert.ToInt32(Console.ReadLine());
    if (userGuess > correctNumber)
        Console.WriteLine("The number is smaller than that");
    else if (userGuess < correctNumber)
        Console.WriteLine("The number is larger than that");
    if (userGuess == correctNumber) {
        string plural = "";
        if (attempts > 1)
            plural = "s";
        Console.WriteLine($"Congrats! You guessed the number with {attempts} attempt{plural}!");
    }
    else
    {
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        attempts++;
    }
}

if (userGuess != correctNumber)
    Console.WriteLine("Sorry! You ran out of attempts!");

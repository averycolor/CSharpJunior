Random random = new Random();

Console.Write("Specify inclusive lower bound: ");
int lowerBound = Convert.ToInt32(Console.ReadLine());

Console.Write("Specify exclusive upper bound: ");
int upperBound = Convert.ToInt32(Console.ReadLine());

while (Console.ReadLine() != "Stop")
{
    int randomNumber = random.Next(lowerBound, upperBound);
    Console.WriteLine(randomNumber);
}

Console.WriteLine("Stopped");

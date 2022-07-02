Console.Write("How old are you? ");
int age = Convert.ToInt32(Console.ReadLine());

int passportAge = 14;
int drivingAge = 16;
int drinkingAge = 18;

string message = $"Since you are {age} years old, ";

if (age >= drinkingAge)
{
    message += "you are allowed to drink, drive, and have a passport.";
}
else if (age >= drivingAge)
{
    message += "you are allowed to drive and have a passport.";
}
else if (age >= passportAge)
{
    message += "you are allowed to have a passport.";
}
else {
    message = "you cannot have a passport, drive, or drink.";
}

Console.WriteLine(message);

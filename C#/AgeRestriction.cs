Console.Write("How old are you? ");
int age = Convert.ToInt32(Console.ReadLine());

Console.Write("What are your test scores?");
int testScore = Convert.ToInt32(Console.ReadLine());
int passingScore = 75;

int passportAge = 14;
int drivingAge = 16;
int drinkingAge = 18;
int universityAge = 17;

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

// && (and) and || (or) can be used to create complex boolean expressions consisting of multiple conditions
if (testScore >= passingScore && age >= universityAge) {
    message += " " + "You are also eligible for a scholarship at Yale.";
}

Console.WriteLine(message);

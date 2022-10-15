string a = "Hello, ";
string b = "World!";

string result = a + b;

Console.WriteLine(result);

// The + operator serves both for addition and concatentaion
// If we want to mix these operations in a single expression, we need to use  ( )
int ageNow = 13;
string name = "Andrew";
string text = "Congrats, " + name + ", you will be " + (ageNow + 1) + " tomorrow!";
// If not for the parenthesis ageNow + 1 would be 131 and not 14 as desired.

// String interpolation/formatting is also possible
string c = "54";
string d = "42";

Console.WriteLine("I am {c} years old, and my friend is {d}");
// This is much more straightforward and looks cleaner and readable as compared to using the + sign.

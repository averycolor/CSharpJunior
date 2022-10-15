Console.Write("What is your name? ");
string name = Console.ReadLine();

Console.Write("What is your favorite character? ");
char frameChar = Convert.ToChar(Console.Read());

int nameLength = name.Length;
int horizontalBarLenth = nameLength + 2;
int verticalBarLength = 3;

string topBar = "";

for (int i = 0; i < horizontalBarLenth; i++)
{
    topBar += frameChar;
}

string bottomBar = topBar;
string middleLine = $"{frameChar}{name}{frameChar}";

Console.Clear();
Console.WriteLine($"{topBar}\n{middleLine}\n{bottomBar}");

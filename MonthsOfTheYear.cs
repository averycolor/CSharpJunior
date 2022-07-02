Console.Write("The month is ");
string currentMonth = Console.ReadLine();

string message;
switch (currentMonth)
{
    case "January":
        message = "It's an exciting new year full of improvement and progression!";
        break;
    case "February":
        message = "Winter is ending, and it is starting to get warmer!";
        break;
    case "March":
        message = "Spring has begun, the birds are coming back and the trees are regrowing their leaves!";
        break;
    case "April":
        message = "It's getting warmer, and farmers start collecting their crops!";
        break;
    case "May":
        message = "Summer is just around the corner!";
        break;
    case "June":
        message = "Summer has begun, it's warm and butterflies are in the air!";
        break;
    case "July":
        message = "It's the hottest month of the year!";
        break;
    case "August":
        message = "Summer is ending!";
        break;
    case "September":
        message = "It's autumn, the leaves are turning brown and falling!";
        break;
    case "October":
        message = "The leaves have fallen, and it's getting colder!";
        break;
    case "November":
        message = "Autumn is over! Nature is falling asleep.";
        break;
    case "December":
        message = "It's winter. It's snowy, the night is longer, and Christmas is just around the corner!";
        break;
    default:
        message = "There is no such month!";
        break;
}

Console.WriteLine(message);

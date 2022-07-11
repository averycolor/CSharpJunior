char[,] map = new char[,] {
    {'#', ' ', ' ', ' ', ' ', '#', '#'},
    {'#', ' ', '#', ' ', ' ', ' ', ' '},
    {'#', ' ', '#', '#', '#', '#', ' '},
    {' ', ' ', '#', '#', '+', '#', ' '},
    {' ', ' ', '#', '#', ' ', '#', ' '},
    {' ', ' ', '#', '#', ' ', ' ', ' '},
    {' ', ' ', '#', '#', '+', ' ', ' '}
};

int playerX = 0;
int playerY = 1;

int scoreLabelLeftMargin = 15;
int scoreLabelTopMargin = 1;

Console.CursorVisible = false;

int score = 0;
int maxScore = 0;
for (int i = 0; i < map.GetLength(0); i++) 
{
    for (int j = 0; j < map.GetLength(1); j++) {
        if (map[i, j] == '+')
            maxScore++;
    }
}

while (score < maxScore) 
{
    Console.Clear();


    for (int i = 0; i < map.GetLength(0); i++)
    {
        for (int j = 0; j < map.GetLength(1); j++)
        {
            Console.Write(map[j, i]);
        }
        Console.WriteLine();
    }

    if (map[playerX, playerY] == '+') {
        score++;
        map[playerX, playerY] = ' ';
    }



    bool   canMoveUp = false,
         canMoveDown = false,
         canMoveLeft = false,
        canMoveRight = false;

    if (playerY - 1 >= 0 && map[playerX, playerY - 1] != '#')
    {
        Console.WriteLine("[W] Move up");
        canMoveUp = true;
    }

    if (playerX - 1 >= 0 && map[playerX - 1, playerY] != '#')
    {
        Console.WriteLine("[A] Move left");
        canMoveLeft = true;
    }
    if (playerY + 1 < map.GetLength(1) && map[playerX, playerY + 1] != '#')
    {
        Console.WriteLine("[S] Move down");
        canMoveDown = true;
    }
    if (playerX + 1 < map.GetLength(0) && map[playerX + 1, playerY] != '#')
    {
        Console.WriteLine("[D] Move right");
        canMoveRight = true;
    }

    Console.SetCursorPosition(playerX, playerY);
    Console.Write('*');

    Console.SetCursorPosition(map.GetLength(1) + scoreLabelLeftMargin, scoreLabelTopMargin);
    Console.WriteLine($"Score: {score}/{maxScore}");
    Console.SetCursorPosition(map.GetLength(1) + scoreLabelLeftMargin, scoreLabelTopMargin + 1);
    Console.WriteLine($"Player X: {playerX}");
    Console.SetCursorPosition(map.GetLength(1) + scoreLabelLeftMargin, scoreLabelTopMargin + 2);
    Console.WriteLine($"Player Y: {playerY}");

    char choice = Console.ReadKey(true).KeyChar;

    switch (choice)
    {
        case 'w':
            if (canMoveUp)
                playerY--;
            break;
        case 'a':
            if (canMoveLeft)
                playerX--;
            break;
        case 's':
            if (canMoveDown)
                playerY++;
            break;
        case 'd':
            if (canMoveRight)
                playerX++;
            break;
    }
}

Console.Clear();
Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
Console.WriteLine("You win!");
Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 1);
Console.WriteLine("[Press any key to exit]");

Console.ReadKey();

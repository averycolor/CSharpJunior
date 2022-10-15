namespace PacMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter level filename (without extension): ");
            string levelName = Console.ReadLine();
            Console.Clear();

            Console.CursorVisible = false;

            Random random = new Random();

            int playerX = 0, playerY = 0;
            int previousPlayerX = playerX, previousPlayerY = playerY;
            int playerDirectionX = 1, playerDirectionY = 0;
            int playerSlowness = 125;

            int enemyX = 0, enemyY = 0;
            int previousEnemyX = enemyX, previousEnemyY = enemyY;
            int enemyDirectionX = 0, enemyDirectionY = 0;

            int targetsCollected = 0;
            int targetsMax = 0;

            bool gameRunning = true;
            bool gameWon = false;

            int mapMaxWidth = 0;
            char[,] map = ReadMap(levelName, out playerX, out playerY, out targetsMax, out mapMaxWidth, out enemyX, out enemyY);

            DrawMap(map);

            while (gameRunning)
            {
                DrawPlayer(playerX, playerY, previousPlayerX, previousPlayerY);
                DrawEnemy(enemyX, enemyY, previousEnemyX, previousEnemyY, map);
                DrawScore(targetsCollected, targetsMax, mapMaxWidth);

                if (Console.KeyAvailable)
                {
                    ConsoleKey keyPressed = Console.ReadKey(true).Key;
                    ChangeMovementDirection(keyPressed, out playerDirectionX, out playerDirectionY);
                }

                previousPlayerX = playerX;
                previousPlayerY = playerY;

                if (
                    playerX + playerDirectionX < map.GetLength(1) &&
                    playerY + playerDirectionY < map.GetLength(0) &&
                    playerX + playerDirectionX >= 0 &&
                    playerY + playerDirectionY >= 0 &&
                    map[playerY + playerDirectionY, playerX + playerDirectionX] != '#'
                )
                {
                    playerX += playerDirectionX;
                    playerY += playerDirectionY;
                }

                if (
                    enemyX + enemyDirectionX < map.GetLength(1) &&
                    enemyY + enemyDirectionY < map.GetLength(0) &&
                    enemyX + enemyDirectionX >= 0 &&
                    enemyY + enemyDirectionY >= 0 &&
                    map[enemyY + enemyDirectionY, enemyX + enemyDirectionX] != '#'
                )
                {
                    previousEnemyX = enemyX;
                    previousEnemyY = enemyY;
                    enemyX += enemyDirectionX;
                    enemyY += enemyDirectionY;
                }

                if (map[enemyY + enemyDirectionY, enemyX + enemyDirectionX] == '#' || (enemyDirectionX == 0 && enemyDirectionY == 0))
                {
                    ChangeMovementDirection(out enemyDirectionX, out enemyDirectionY, random);
                }

                if (map[playerY, playerX] == '+')
                {
                    targetsCollected++;
                    map[playerY, playerX] = ' ';
                }

                Thread.Sleep(playerSlowness);

                if (targetsCollected >= targetsMax)
                {
                    gameRunning = false;
                    gameWon = true;
                }

                if (enemyX + enemyDirectionX == playerX && enemyY + enemyDirectionY == playerY)
                {
                    gameRunning = false;
                }
            }

            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);

            if (gameWon)
                Console.WriteLine("You win!");
            else
                Console.Write("You lose!");
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                { 
                    char mapChar = map[i, j];

                    ConsoleColor lastForegroundColor = Console.ForegroundColor;

                    if (mapChar == '+')
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    Console.Write(mapChar);
                    Console.ForegroundColor = lastForegroundColor;
                }
                Console.WriteLine();
            }
        }

        static void DrawScore(int targetsCollected, int targetsMax, int mapMaxWidth)
        {
            int lastCursorX = Console.CursorLeft;
            int lastCursorY = Console.CursorTop;

            string scoreLabelFormat = "Score: {0}/{1}";
            string scoreLabelText = String.Format(scoreLabelFormat, targetsCollected, targetsMax);
            int scoreLabelLength = scoreLabelText.Length;

            Console.SetCursorPosition(mapMaxWidth + scoreLabelLength, 1);
            Console.Write(scoreLabelText);

            Console.SetCursorPosition(lastCursorX, lastCursorY);
        }

        static void ChangeMovementDirection(ConsoleKey keyPressed, out int playerDirectionX, out int playerDirectionY)
        {
            playerDirectionX = 0;
            playerDirectionY = 0;
            switch (keyPressed)
            {
                case ConsoleKey.W:
                    playerDirectionX = 0;
                    playerDirectionY = -1;
                    break;
                case ConsoleKey.A:
                    playerDirectionX = -1;
                    playerDirectionY = 0;
                    break;
                case ConsoleKey.S:
                    playerDirectionX = 0;
                    playerDirectionY = 1;
                    break;
                case ConsoleKey.D:
                    playerDirectionX = 1;
                    playerDirectionY = 0;
                    break;
            }
        }

        static void ChangeMovementDirection(out int enemyDirectionX, out int enemyDirectionY, Random random)
        {
            int newDirection = random.Next(0, 4);
            int newDirectionX = 0, newDirectionY = 0;

            switch (newDirection)
            {
                case 0:
                    newDirectionX = 0;
                    newDirectionY = 1;
                    break;
                case 1:
                    newDirectionX = 1;
                    newDirectionY = 0;
                    break;
                case 2:
                    newDirectionX = 0;
                    newDirectionY = -1;
                    break;
                case 3:
                    newDirectionX = -1;
                    newDirectionY = 0;
                    break;
            }

            enemyDirectionX = newDirectionX;
            enemyDirectionY = newDirectionY;
        }

        static void DrawPlayer(int playerX, int playerY, int previousPlayerX, int previousPlayerY, ConsoleColor color = ConsoleColor.DarkBlue)
        {
            int lastCursorPositionX = Console.CursorLeft;
            int lastCursorPositionY = Console.CursorTop;

            Console.SetCursorPosition(previousPlayerX, previousPlayerY);
            Console.Write(' ');

            Console.SetCursorPosition(playerX, playerY);
            ConsoleColor lastForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write('*');
            Console.ForegroundColor = lastForegroundColor;

            Console.SetCursorPosition(lastCursorPositionX, lastCursorPositionY);
        }

        static void DrawEnemy(int enemyX, int enemyY, int previousEnemyX, int previousEnemyY, char[,] map, ConsoleColor color = ConsoleColor.DarkRed)
        {
            int lastCursorPositionX = Console.CursorLeft;
            int lastCursorPositionY = Console.CursorTop;

            Console.SetCursorPosition(previousEnemyX, previousEnemyY);

            ConsoleColor lastForegroundColor = Console.ForegroundColor;
            char charAtPreviousEnemyPosition = map[previousEnemyY, previousEnemyX];

            if (charAtPreviousEnemyPosition == '+')
                Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write(charAtPreviousEnemyPosition);

            Console.SetCursorPosition(enemyX, enemyY);

            Console.ForegroundColor = color;
            Console.Write('x');
            Console.ForegroundColor = lastForegroundColor;

            Console.SetCursorPosition(lastCursorPositionX, lastCursorPositionY);
        }

        static char[,] ReadMap(string mapName, out int playerX, out int playerY, out int maxTargets, out int mapMaxWidth, out int enemyX, out int enemyY)
        {
            int targets = 0;

            char mapChar = '#';
            char playerChar = '*';
            char enemyChar = 'x';

            string pathToMapFile = $"Maps/{mapName}.txt";
            string[] mapFileLines = File.ReadAllLines(pathToMapFile);

            int mapWidth = mapFileLines.Length;
            int mapHeight = 0;

            foreach (string mapFileLine in mapFileLines)
            {
                if (mapFileLine.Length > mapHeight)
                {
                    mapHeight = mapFileLine.Length;
                }
            }

            char[,] map = new char[mapWidth, mapHeight];

            int playerCharX = 0, playerCharY = 0;
            int enemyCharX = 0, enemyCharY = 0;

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    char currentChar;

                    if (j < mapFileLines[i].Length)
                    {
                        currentChar = mapFileLines[i][j];
                        map[i, j] = '+';
                        targets++;

                        if (currentChar == playerChar)
                        {
                            playerCharX = j;
                            playerCharY = i;
                            targets--;
                        }
                        else if (currentChar == mapChar)
                        {
                            map[i, j] = currentChar;
                            targets--;
                        }
                        else if (currentChar == enemyChar)
                        {
                            enemyCharX = j;
                            enemyCharY = i;
                        }
                    }
                }
            }

            playerX = playerCharX;
            playerY = playerCharY;
            maxTargets = targets + 1;

            mapMaxWidth = mapWidth;

            enemyX = enemyCharX;
            enemyY = enemyCharY;

            return map;
        }
    }
}

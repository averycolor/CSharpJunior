namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();
            Player player = new Player(0, 0);

            while (true)
            {
                renderer.NextFrame();

                player.Move(1, 1);
                renderer.DrawPlayer(player);

                Thread.Sleep(1000);
            }
        }
    }

    class Renderer
    {
        public int Frame { get; private set; }

        public void NextFrame()
        {
            Frame++;
            Console.Clear();
        }

        public void DrawPlayer(Player player)
        {
            int previousCursorX = Console.CursorLeft;
            int previousCursorY = Console.CursorTop;

            Console.SetCursorPosition(player.X, player.Y);
            Console.Write(player.Char);

            Console.SetCursorPosition(previousCursorX, previousCursorY);
        }
    }

    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Char { get; private set; }

        public Player(int x, int y, char ch = '*')
        {
            X = x;
            Y = y;
            Char = ch;
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }
}

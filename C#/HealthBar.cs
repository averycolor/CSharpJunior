namespace HealthBar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 10;
            int minHealth = 0;
            int maxHealth = 100;
            int barWidth = 10;

            while (true)
            {
                Console.Clear();
                DrawBar("Health", minHealth, health, maxHealth, barWidth, display: '|');

                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.Escape)
                    break;
                else if (keyPressed == ConsoleKey.RightArrow)
                    health++;
                else if (keyPressed == ConsoleKey.LeftArrow)
                    health--;
            }
        }

        static void DrawBar(string label, int minValue, int value, int maxValue, int width, char display = '|', bool showValue = true) { 
            int valueClamped = Math.Clamp(value, minValue, maxValue);
            float valuePercent = Convert.ToSingle(valueClamped) / (maxValue - minValue);
            float valueWidth = valuePercent * width;
            int displayWidth = Convert.ToInt32(valueWidth);

            Console.Write(label + " ");

            for (int i = 0; i < displayWidth; i++) 
            {
                Console.Write(display);
            }

            if (showValue)
                Console.Write(" " + value);
        }
    }
}

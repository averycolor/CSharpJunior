namespace StateUpdate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mover mover = new Mover();
            Jumper jumper = new Jumper();

            while (true)
            {
                mover.Update();
                jumper.Update();
                Console.WriteLine("---------");
                Console.ReadKey(true);
            }
        }
    }

    class Behavior
    {
        public virtual void Update()
        {

        }
    }

    class Mover : Behavior
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public override void Update()
        {
            X++;
            Y++;
            Console.WriteLine($"Mover: {X} {Y}");
        }
    }

    class Jumper : Behavior {
        public int Altitude { get; private set; }

        public override void Update()
        {
            Altitude++;
            Console.WriteLine($"Jumper: {Altitude}");
        }
    }
}

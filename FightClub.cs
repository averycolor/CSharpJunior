namespace FightClubOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fighter[] fighters =
            {
                new Fighter("Andrew", 20, 100, 100),
                new Fighter("Max", 15, 75, 90),
                new Fighter("John", 25, 45, 150),
                new Fighter("Jacob", 40, 90, 55),
                new Fighter("Joseph", 10, 95, 45),
                new Fighter("Mike", 10, 50, 100),
                new Fighter("A2", 1, 50, 100)
            };

            for (int i = 0; i < fighters.Length; i++)
            {
                Console.WriteLine($"[{i}] " + fighters[i].Summary());
            }

            Console.Write("Pick first fighter (enter index): ");
            int firstFighterIndex = Convert.ToInt32(Console.ReadLine());

            Console.Write("Pick second fighter (enter index): ");
            int secondFighterIndex = Convert.ToInt32(Console.ReadLine());

            Fighter fighter1 = fighters[firstFighterIndex];
            Fighter fighter2 = fighters[secondFighterIndex];

            while (fighter1.TakeDamage(fighter2.Damage) && fighter2.TakeDamage(fighter1.Damage))
            {
                Console.Clear();
                Console.WriteLine($"{fighter1.Name} vs {fighter2.Name}");
                Console.WriteLine($"Fighter 1: {fighter1.Health}");
                Console.WriteLine($"Fighter 2: {fighter2.Health}");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
            }

            if (fighter1.Health > 0)
            {
                Console.WriteLine($"{fighter1.Name} won the battle!");
            }
            else {
                Console.WriteLine($"{fighter2.Name} won the battle!");
            }
        }
    }

    class Fighter
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }
        public int Health { get; private set; }

        public Fighter(string name, int damage, int armor, int health)
        {
            Name = name;
            Damage = damage;
            Armor = armor;
            Health = health;
        }

        public string Summary()
        {
            return $"{Name} ({Damage}DMG {Armor}DEF {Health}HP)";
        }

        public bool TakeDamage(int damage)
        {
            bool isAliveAfterHit;
            int healthAfterHit = Health - Convert.ToInt32(damage * (Armor / 100f));

            if (healthAfterHit > 0)
            {
                Health = healthAfterHit;
                isAliveAfterHit = true;
            }
            else {
                Health = 0;
                isAliveAfterHit = false;
            }

            return isAliveAfterHit;
        }
    }
}

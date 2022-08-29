namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Army A Fighters: ");
            int armyAFighterCount = ReadInt();
            Console.Write("Army B Fighters: ");
            int armyBFighterCount = ReadInt();

            Army armyA = new Army(armyAFighterCount, 100, 120, 50, 70, 80, 90);
            Army armyB = new Army(armyBFighterCount, 100, 120, 50, 70, 80, 90);

            Battle battle = new Battle(armyA, armyB);
            battle.Work();
        }

        static int ReadInt()
        {
            int inputtedInteger;

            while (int.TryParse(Console.ReadLine(), out inputtedInteger) == false) { }

            return inputtedInteger;
        }
    }

    class Army
    {
        private List<Fighter> _fighters;
        private Random _random;

        public bool HasLivingFighters
        {
            get
            {
                foreach (Fighter fighter in _fighters)
                {
                    if (fighter.IsAlive)
                        return true;
                }

                return false;
            }
        }

        public Army(int fighterCount, int minFighterHealth, int maxFighterHealth, int minFighterDefense, int maxFighterDefense, int minFighterDamage, int maxFighterDamage)
        {
            _random = new Random();
            _fighters = new List<Fighter>();

            for (int i = 0; i < fighterCount; i++)
            {
                _fighters.Add(
                    new Fighter
                    (
                        _random.Next(minFighterDamage, maxFighterDamage),
                        _random.Next(minFighterHealth, maxFighterHealth),
                        _random.Next(minFighterDefense, maxFighterDefense)
                    )
                );
            }
        }

        public Fighter GetRandomFighter()
        {
            return _fighters[_random.Next(_fighters.Count)];
        }
    }

    class Fighter
    {
        private int _health;

        public int MaxHealth { get; private set; }
        public int Health
        {
            get
            {
                return _health;
            }
            private set
            {
                if (value > MaxHealth)
                    _health = MaxHealth;
                else if (value < 0)
                    _health = 0;
                else
                    _health = value;
                IsAlive = _health > 0;
            }
        }
        public int Damage { get; private set; }
        public int Defense { get; private set; }
        public bool IsAlive { get; private set; }

        public Fighter (int damage, int maxHealth, int defense)
        {
            Damage = damage;
            Health = maxHealth;
            MaxHealth = maxHealth;
            Defense = defense;
            IsAlive = true;
        }

        public void TakeDamage(int damage)
        {
            int damageToTake = damage * Defense / 100;

            if (damageToTake > 0)
                Health -= damageToTake;
        }

        public void Attack(Fighter target)
        {
            target.TakeDamage(Damage);
        }

        public void TakeHealing(int healing)
        {
            if (healing > 0)
                Health += healing;
        }
    }

    class Battle
    {
        private Army _armyA;
        private Army _armyB;

        public Battle(Army armyA, Army armyB)
        {
            _armyA = armyA;
            _armyB = armyB;
        }

        public void Work()
        {
            while (_armyA.HasLivingFighters && _armyB.HasLivingFighters)
            {
                _armyA.GetRandomFighter().Attack(_armyB.GetRandomFighter());
                _armyB.GetRandomFighter().Attack(_armyA.GetRandomFighter());
            }

            if (_armyA.HasLivingFighters == false && _armyB.HasLivingFighters == false)
            {
                Console.WriteLine("Draw!");
            }
            else if (_armyA.HasLivingFighters)
            {
                Console.WriteLine("Army A won!");
            }
            else
            {
                Console.WriteLine("Army B won!");
            }
        }
    }
}

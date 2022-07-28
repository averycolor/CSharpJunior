namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Warrior
    {
        public int Armor;
        public int Health;
        public int Damage;

        public Warrior(int armor, int health, int damage)
        {
            Armor = armor;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }
    }

    class Knight : Warrior
    {
        private int _prayArmorBoost = 2;

        public Knight(int prayArmorBoost, int armor, int health, int damage) : base(armor, health, damage)
        {
            _prayArmorBoost = prayArmorBoost;
        }

        public void Pray()
        {
            Armor += _prayArmorBoost;
        }
    }

    class Barbarian : Warrior
    {
        private int _shoutHealthBoost = -10;
        private int _shoutDamageBoost = 30;

        public Barbarian(int shoutHealthBoost, int shoutDamageBoost, int armor, int health, int damage) : base(armor, health, damage)
        {
            _shoutHealthBoost = shoutHealthBoost;
            _shoutDamageBoost = shoutDamageBoost;
        }

        public void Shout() {
            Health += _shoutHealthBoost;
            Damage += _shoutDamageBoost;
        }
    }
}

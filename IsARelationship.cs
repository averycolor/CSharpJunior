namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight(10, 5, 100, 21);
            Barbarian barbarian = new Barbarian(-5, 10, 16, 70, 40);
        }
    }

    class Warrior
    {
        protected int _armor;
        protected int _health;
        protected int _damage;

        public Warrior(int armor, int health, int damage)
        {
            _armor = armor;
            _health = health;
            _damage = damage;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage - _armor;
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
            _armor += _prayArmorBoost;
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
            _health += _shoutHealthBoost;
            _damage += _shoutDamageBoost;
        }
    }
}

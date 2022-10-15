string bossName = "Hazulamaak";
int bossHealth = 3200;
int bossDefense = 60;
int bossDamage = 125;
int bossCriticalHitChance = 15;
int bossCriticalHitDamage = 300;

int playerHealth = 400;
int playerDefense = 52;

string spell1Name = "Haaziweek";
int spell1Damage = 500;
bool canCastSpell1 = true;

string spell2Name = "Haazifini";
int spell2Damage = 165;
bool canCastSpell2 = false;

string spell3Name = "Gardival";
int spell3Damage = 0;
int spell3PlayerDefenseBoost = 45;
int spell3BossDefenseDecrease = 10;
int spell3Recoil = 100;
bool canCastSpell3 = false;
int spell3TurnsLeft = 0;
int spell3EffectDuration = 3;

string spell4Name = "Tansferos";
int spell4LeechMin = 200;
int spell4LeechMax = 260;
Random random = new Random();
bool spell4Cast = false;

int spell3HealthThreshold = 100;


Console.WriteLine($"You encountered {bossName} ({bossHealth}HP, {bossDefense}DEF, {bossDamage}DMG)");
Console.WriteLine("[ANY KEY] Start fight");
Console.ReadKey();
Console.Clear();

bool bossAlive = bossHealth > 0;
bool playerAlive = playerHealth > 0;

int turn = 1;
string spellHistory = "";

 int healthBarResolution = 10;

while (bossAlive && playerAlive)
{
    Console.Clear();
    Console.Write("Boss: ");

    for (int i = 0; i < bossHealth / healthBarResolution; i += healthBarResolution)
    {
        Console.Write("*");
    }

    Console.Write(" " + bossHealth);
    Console.WriteLine();

    Console.Write("You : ");

    for (int i = 0; i < playerHealth / healthBarResolution; i += healthBarResolution)
    {
        Console.Write("*");
    }

    Console.Write(" " + playerHealth);
    Console.WriteLine();

    Console.WriteLine("Your turn!");

    char lastSpell = ' ';

    if (spellHistory.Length != 0)
        lastSpell = spellHistory[spellHistory.Length - 1];

    Console.WriteLine("Spells available: ");

    if (lastSpell != '1')
    {
        canCastSpell1 = true;
        Console.WriteLine($"[1] {spell1Name}");
    }
    else
    {
        canCastSpell1 = false;
    }

    if (lastSpell == '1' || lastSpell == '1')
    {
        canCastSpell2 = true;
        Console.WriteLine($"[2] {spell2Name}");
    }
    else
    {
        canCastSpell2 = false;
    }

    if (playerHealth > spell3HealthThreshold)
    {
        canCastSpell3 = true;
        Console.WriteLine($"[3] {spell3Name}");
    }
    else
    {
        canCastSpell3 = false;
    }

    if (spell4Cast == false)
    {
        Console.WriteLine($"[4] {spell4Name}");
    }

    char choice = Convert.ToChar(Console.ReadKey().KeyChar);

    Console.Clear();

    switch (choice)
    {
        case '1':
            if (canCastSpell1 == false) 
                break;

            Console.WriteLine($"You cast {spell1Name}");
            Console.WriteLine($"You concentrated all the lightning in the world on the enemy and dealt {spell1Damage} damage.");

            int bossDamagePerceptionPercent = 100 - bossDefense;

            if (bossDamagePerceptionPercent > 0)
                bossHealth -= spell1Damage / (100 / bossDamagePerceptionPercent);

            spellHistory += choice;
            break;
        case '2':
            if (canCastSpell2 == false) 
                break;

            Console.WriteLine($"You cast {spell2Name}");
            Console.WriteLine($"You electrocuted the enemy. You dealt {spell2Damage} damage.");
            bossHealth -= spell2Damage / (100 / (100 - bossDefense));
            spellHistory += choice;
            break;
        case '3':
            if (canCastSpell3 == false) 
                break;

            Console.WriteLine($"You cast {spell3Name}");
            Console.WriteLine("The spirits are in your favor.");
            Console.WriteLine($"The enemy's defense fell by {spell3BossDefenseDecrease}");
            Console.WriteLine($"Your defense increased by {spell3PlayerDefenseBoost}");
            Console.WriteLine("However, you had to sacrifice 100 HP to the gods.");
            bossDefense -= spell3BossDefenseDecrease;
            playerHealth -= spell3Recoil;
            playerDefense += spell3PlayerDefenseBoost;
            spellHistory += choice;
            spell3TurnsLeft = spell3EffectDuration;
            break;
        case '4':
            if (spell4Cast) 
                break;

            Console.WriteLine($"You cast {spell4Name}");
            spell4Cast = true;
            int leech = random.Next(spell4LeechMin, spell4LeechMax + 1);
            Console.WriteLine($"You leeched {leech} health from the boss.");
            bossHealth -= leech;
            playerHealth += leech;
            spellHistory += choice;
            break;
        default:
            Console.WriteLine("You couldn't cast a spell and stood still.");
            break;
    }

    Console.WriteLine("[ANY KEY] Continue");
    Console.ReadKey(true);

    string critical = "";
    int damageToPlayer = bossDamage;

    if (random.Next(0, 101) < bossCriticalHitChance)
    {
        critical = "critical";
        damageToPlayer = bossCriticalHitDamage;
    }

    int playerDamagePerceptionPercent = 100 - playerDefense;
    if (playerDamagePerceptionPercent > 0)
        damageToPlayer /= 100 / (playerDamagePerceptionPercent);
    else
        damageToPlayer = 0;
    damageToPlayer = Math.Clamp(damageToPlayer, 0, int.MaxValue);

    Console.WriteLine($"The enemy responded with a {critical} hit, dealing you {damageToPlayer} damage.");
    playerHealth -= damageToPlayer;
    Console.WriteLine("[ANY KEY] Continue");
    Console.ReadKey();

    bossAlive = bossHealth > 0;
    playerAlive = playerHealth > 0;

    turn++;

    if (spell3TurnsLeft > 0)
    {

        spell3TurnsLeft--;

        if (spell3TurnsLeft == 0)
        {
            playerDefense -= spell3PlayerDefenseBoost;
            bossDefense += spell3BossDefenseDecrease;
        }

    }

}

Console.Clear();

if (bossAlive)
{
    Console.WriteLine("Severely wounded, you retreated back to your hut on the cliff...");
}
else
{
    Console.WriteLine("From this dramatic battle you emerged victorious!");
}

Console.WriteLine("Game over");

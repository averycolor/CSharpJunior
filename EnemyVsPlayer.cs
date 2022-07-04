Console.Write("[Player Max HP] ");
int playerMaxHP = Convert.ToInt32(Console.ReadLine());
Console.Write("[Player Damage] ");
int playerDamage = Convert.ToInt32(Console.ReadLine());
Console.Write("[Enemy Max HP] ");
int enemyMaxHP = Convert.ToInt32(Console.ReadLine());
Console.Write("[Enemy Damage] ");
int enemyDamage = Convert.ToInt32(Console.ReadLine());

int playerHP = playerMaxHP;
int enemyHP = enemyMaxHP;

Console.Write("[Enemy Potions] ");
int enemyPotions = Convert.ToInt32(Console.ReadLine());
Console.Write("[Enemy Heal Health Level] ");
int enemyHealHealthLevel = Convert.ToInt32(Console.ReadLine()); // 0..100;
Console.Write("[Enemy Heal Chance] ");
int enemyHealChance = Convert.ToInt32(Console.ReadLine());
Console.Write("[Enemy Heal Percent Min] ");
int enemyHealPercentMin = Convert.ToInt32(Console.ReadLine());
Console.Write("[Enemy Heal Percent Max] ");
int enemyHealPercentMax = Convert.ToInt32(Console.ReadLine());

Console.Write("[Player Potions] ");
int playerPotions = Convert.ToInt32(Console.ReadLine());
Console.Write("[Player Heal Percent Min] ");
int playerHealPercentMin = Convert.ToInt32(Console.ReadLine());
Console.Write("[Player Heal Percent Max] ");
int playerHealPercentMax = Convert.ToInt32(Console.ReadLine());

Console.Write("[Player Crit Chance] ");
int playerCritChance = Convert.ToInt32(Console.ReadLine());
Console.Write("[Enemy Crit Chance] ");
int enemyCritChance = Convert.ToInt32(Console.ReadLine());

int turn = 1;

while (playerHP > 0 && enemyHP > 0)
{
    Console.Clear();
    Console.WriteLine($"Turn {turn}");
    Console.WriteLine("[1] Attack");
    Console.WriteLine($"[2] Heal (Potions: {playerPotions})");
    int choice = 0;
    while (choice != 1 && choice != 2)
        choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            int damageToEnemy = playerDamage;
            enemyHP -= damageToEnemy;
            Console.WriteLine($"You attacked the enemy, and dealt {damageToEnemy} damage.");
            break;
        case 2:
            int healSize = Convert.ToInt32(Math.Round(Convert.ToDouble(playerMaxHP * (new Random().Next(playerHealPercentMin, playerHealPercentMax + 1) / 100f))));
            playerHP += healSize;
            playerPotions--;
            Console.WriteLine($"You healed, and gained {healSize} HP.");
            break;
        default:
            break;
    }
    // Enemy's turn
    if ((Convert.ToSingle(enemyHP) / enemyMaxHP) * 100 < enemyHealHealthLevel)
    {
        // Enemy heals with a certain chance
        int chance = new Random().Next(0, 100);
        if (chance < enemyHealChance) {
            int healSize = Convert.ToInt32(Math.Round(Convert.ToDouble(enemyMaxHP * (new Random().Next(enemyHealPercentMin, enemyHealPercentMax + 1) / 100f))));
            enemyHP += healSize;
            Console.WriteLine($"The enemy healed, and gained {healSize} HP.");
            enemyPotions--;
        }
    } else
    {
        // Enemy attacks
        int damageToPlayer = enemyDamage;
        playerHP -= damageToPlayer;
        Console.WriteLine($"The enemy attacked you, and dealt {damageToPlayer} damage.");

    }

    enemyHP = Math.Clamp(enemyHP, 0, enemyMaxHP);
    playerHP = Math.Clamp(playerHP, 0, playerMaxHP);

    Console.WriteLine($"Enemy HP  : {enemyHP}/{enemyMaxHP}");
    Console.WriteLine($"Player HP : {playerHP}/{playerMaxHP}");
    Console.WriteLine("[Press any key to continue]");
    Console.ReadKey();

    turn++;
}

Console.Clear();
if (playerHP <= 0 && enemyHP <= 0)
    Console.WriteLine("Draw!");
else if (playerHP <= 0)
    Console.WriteLine("You lose!");
else if (enemyHP <= 0)
    Console.WriteLine("You win!");

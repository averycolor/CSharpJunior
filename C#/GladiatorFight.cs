Random random = new Random();

int health1 = random.Next(10, 100);
int damage1 = random.Next(1,   10);
int armor1  = random.Next(1,   10);

int health2 = random.Next(10, 100);
int damage2 = random.Next(1,   10);
int armor2  = random.Next(1,   10);

int damageVariationPercent = 10;

Console.WriteLine($"Welcome to the Stadium! Today, two gladiators are fighting!");
Console.WriteLine($"One of them has {health1} health, deals {damage1} damage, and his armor weight {armor1} kilos.");
Console.WriteLine($"Another one has {health2} health, deals {damage2} damage, and his armor weight {armor2} kilos.");
Console.WriteLine("Press any key to start the fight!");
Console.ReadKey();


while (true)
{
    int damageTo2 = Math.Clamp(damage1 - armor2, 0, 100) * random.Next(100-damageVariationPercent, 100+damageVariationPercent) / 100;
    health2 -= damageTo2;
    if (damageTo2 > 0)
        Console.WriteLine($"The first gladiator attacked the second one, and dealt {damage1} damage. The other gladiator's health decreased by {damageTo2}");
    else
        Console.WriteLine($"The first gladiator's blow did not even leave a scratch on the second gladiator's body!");
    if (health2 <= 0)
    {
        Console.WriteLine("The second gladiator dropped dead.");
        break;
    }

    int damageTo1 = Math.Clamp(damage2 - armor1, 0, 100) * random.Next(100-damageVariationPercent, 100+damageVariationPercent) / 100;
    health1 -= damageTo1;
    if (damageTo1 > 0)
        Console.WriteLine($"The second gladiator attacked the first one, and dealt {damage2} damage. The other gladiator's health decreased by {damageTo1}");
    else
        Console.WriteLine($"The second gladiator's blow did not even leave a scratch on the first gladiator's body!");
    if (health1 <= 0) {
        Console.WriteLine("The first gladiator dropped dead.");
        break;
    }

    Console.Write("Press any key to continue");
    Console.ReadKey();
    Console.Clear();
}

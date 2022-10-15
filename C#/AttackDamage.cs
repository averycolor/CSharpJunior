// Task: given the current health, armor of a character, determine how much health they will have left, given that armor [0;100] and represents the percentage of damage that gets to the player

Console.Write("Health: ");
float health = Convert.ToSingle(Console.ReadLine());
Console.Write("Armor: ");
int armor = Convert.ToInt32(Console.ReadLine()); 
Console.Write("Enemy Damage: ");
int enemyDamage = Convert.ToInt32(Console.ReadLine());

health -= enemyDamage / Convert.ToSingle(100) * armor;

Console.WriteLine(
    $"After an attack with a strenth of {enemyDamage}," +
    $" your armor took {100-armor}% of the blow," +
    $" and you now have {health} health remaining"
);

Console.Write("Length of array A: ");
int lengthA = Convert.ToInt32(Console.ReadLine());

int[] arrayA = new int[lengthA];

for (int i = 0; i < lengthA; i++) {
    Console.Write($"Array A [{i}] = ");
    arrayA[i] = Convert.ToInt32(Console.ReadLine());
}

int[] arrayB = new int[lengthA + 1];

for (int i = 0; i < lengthA; i++)
{
    arrayB[i] = arrayA[i];
}

Console.Write("Element to add after expansion? ");
arrayB[arrayB.Length - 1] = Convert.ToInt32(Console.ReadLine());
arrayA = arrayB;

Console.Write("Array A after expansion: ");
for (int i = 0; i < arrayA.Length; i++) {
    Console.Write($"{arrayA[i]} ");
}

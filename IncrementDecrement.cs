int a = 0;
Console.WriteLine(a++);
// 0
// Despite ++ placed after the variable name supposedly increasing it, the change is only reflected the next time the variable is referenced

int b = 0;
Console.WriteLine(++b);
// 1
// ++ is placed before the variable name, meaning that the change is reflected the same reference.

// Decrement works similarly, but instead decreases the value by 1

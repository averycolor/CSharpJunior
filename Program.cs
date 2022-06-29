// While all other traditional arithmetical operations in C# are straightfoward,
// Division has its specifics
int a = 5;
int b = 4;
float result = a / b;
// The output should be 1.25, but it's 1 instead, because C# truncates floating points
// For division results of two integers

// At least one od the operands must have a floating point in order for the division to
// yield a correct result
float actualResult = Convert.ToSingle(a) / b;

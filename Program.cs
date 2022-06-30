int age;
string str = "17";

// age = str will not work because integers and strings are different data types and do not automatically convert
// Instead:

age = Convert.ToInt32(str);

// age will now equal 17

float result;
float a = 3, b = 2;
result = a / b; // will give 1 instead of correct 1.5

// We need to convert, which can also be done using the Convert.ToSingle

result = Convert.ToSingle(a) / b;

// At least one operand of the division operation needs to be a float/double in order for the result to have a floating point

bool b1 = Convert.ToBoolean(0);
bool b2 = Convert.ToBoolean(1);

int i1 = Convert.ToInt32(b1);
int i2 = Convert.ToInt32(b2);

// Converting a value to a boolean will work as intended, and converting a boolean to another type will return the value most commonly thought of as the counterpart of the boolean value
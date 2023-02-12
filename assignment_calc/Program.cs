var variable = "2 + 2 * 2";
char[] operators = new char[] { '+', '-', '/', '*' };

List<string> operations = new List<string>(); // list of strings (operators)

var buff = ""; // creating empty buffer
char? oper = null; // for storing the operator

foreach (var ch in variable)
{
    if (Char.IsDigit(ch)) //checking if it's a digit
    {
        buff += ch; // if yes - adding it to the buffer
    }
    else if (operators.Contains(ch)) // checking if it's an operator
    {
        operations.Add(buff); // adding this operator to the buffer
        buff = ""; // cleaning the buff
        if (oper is not null) // checking if oper is not empty
        {
            operations.Add(oper.ToString()); //if not - addind a string of that operator
        }
        oper = ch; 
    }
}

if (buff != "") // if buff contains something
{
    operations.Add(buff); // add it to the operations
    operations.Add(oper.ToString());
}

foreach (var operation in operations)
{
    Console.WriteLine(operation);
}
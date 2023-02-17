using assignment_calc;
using Stack = assignment_calc.Stack;

Console.Write("> ");
var variable = Console.ReadLine();
char[] operators = new char[] { '+', '-', '/', '*' };

Dictionary<string, int> dict = new Dictionary<string, int>();
dict.Add("+", 2);
dict.Add("-", 2);
dict.Add("*", 3);
dict.Add("/", 3);
dict.Add("^", 4);

Dictionary<string, string> assos = new Dictionary<string, string>();
assos.Add("+", "left");
assos.Add("-", "left");
assos.Add("*", "left");
assos.Add("/", "left");
assos.Add("^", "right");

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
        if (buff != "") operations.Add(buff); // adding this operator to the buffer
        buff = ""; // cleaning the buff
        oper = ch;
        if (oper is not null) // checking if oper is not empty
        {
            operations.Add(oper.ToString()); //if not - addind a string of that operator
        }
    }
}

if (buff != "") // if buff contains something
{
    operations.Add(buff); // add it to the operations
}


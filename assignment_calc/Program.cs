var variable = "2 + 2 * 2";
char[] operators = new char[] { '+', '-', '/', '*' };

List<string> operations = new List<string>();

var buff = "";
char? oper = null;

foreach (var ch in variable)
{
    if (Char.IsDigit(ch))
    {
        buff += ch;
    }
    else if (operators.Contains(ch))
    {
        operations.Add(buff);
        buff = "";
        if (oper is not null)
        {
            operations.Add(oper.ToString());
        }
        oper = ch;
    }
}

if (buff != "")
{
    operations.Add(buff);
    operations.Add(oper.ToString());
}

foreach (var operation in operations)
{
    Console.WriteLine(operation);
}
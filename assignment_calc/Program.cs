using assignment_calc;
using Stack = assignment_calc.Stack;

Console.Write("> ");
var variable = Console.ReadLine();
char[] operators = new char[] { '+', '-', '/', '*', '^', '(', ')' };

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
char? oper; // for storing the operator

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

// shunting yard algorithm

var stack = new Stack();
var results = new Queue();
foreach (var operation in operations)
{
    if (int.TryParse(operation, out int n))
    {
        results.Enqueue(operation);
    }
    else if (operation == "(")
    {
        stack.Push(operation);
    }
    else if (operation == ")")
    {
        while (stack.Peek() != "(")
        {
            results.Enqueue(stack.Pop());
        }

        stack.Pop();
    }
    else
    {
        while (
            stack.Count() != 0 &&
            (
                stack.Peek() != "(" &&
                (
                    dict[stack.Peek()] > dict[operation] ||
                    (
                        dict[stack.Peek()] == dict[operation] &&
                        assos[operation] == "left"
                    )
                )
            )
        )
        {
            results.Enqueue(stack.Peek());
            stack.Pop();
        }

        stack.Push(operation);
    }
}


foreach (var token in stack.GetElements())
{
    if (token != null)
    {
        results.Enqueue(token);
    }
}

foreach (var operation in results.GetElements())
{
    if (operation != null)
    { 
        Console.WriteLine(operation);
    }
}

string CalculateResult(Queue postfixTokens)
{
    var buffer = new Stack();
    while (postfixTokens.Count() != 0)
    {
        var token = postfixTokens.Dequeue();
        if (double.TryParse(token, out _))
        {
            buffer.Push(token);
        }
        else
        {
            var secondNumber = buffer.Peek();
            buffer.Pop();
            var firstNumber = buffer.Peek();
            buffer.Pop();
            var calc = Count(firstNumber, secondNumber, token);
            buffer.Push(calc);
        }
    }

    var result = buffer.Peek();
    return result;
}


string Count(string firstNum, string secondNum, string oper)
{
    double result = 0;
    switch (oper)
    {
        case "+":
            result = double.Parse(firstNum) + double.Parse(secondNum);
            break;
        case "-":
            result = double.Parse(firstNum) - double.Parse(secondNum);
            break;
        case "/":
            result = double.Parse(firstNum) / double.Parse(secondNum);
            break;
        case "*":
            result = double.Parse(firstNum) * double.Parse(secondNum);
            break;
        case "^":
            result = Math.Pow(double.Parse(firstNum), double.Parse(secondNum));
            break;
        default:
            throw new Exception("Illegal operation");
    }

    return result.ToString();
}

string output = String.Format("< {0}", CalculateResult(results));
Console.WriteLine(output);

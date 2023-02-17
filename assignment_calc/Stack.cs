namespace assignment_calc;

public class Stack
{
    private static int _capacity = 15;
    private int _pointer;
    private string[] _array = new string[_capacity];

    public void Push(string element)
    {
        if (_capacity != _pointer)
        {
            _array[_pointer] = element;
            _pointer++;
        }
        else
        {
            _capacity = _capacity * 2;

            string[] temporaryArray = new string[_capacity];
            for (int i = 0; i < _pointer; i++)
            {
                temporaryArray[i] = _array[i];
            }

            _array = temporaryArray;
            _array[_pointer] = element;
            _pointer++;
        }
    }

    public string? Pop()
    {
        if (_pointer != 0)
        {
            var tmp = _array[_pointer - 1];
            _array[_pointer - 1] = null!;
            _pointer--;
            return tmp;
        }
        else
        {
            Console.WriteLine("Stack is empty");
            return null;
        }
    }

    public string Peek()
    {
        if (_pointer == 0)
        {
            Console.WriteLine("Stack is empty");
        }

        if (_pointer != 0)
        {
            return _array[_pointer - 1];
        }

        return "null";
    }

    public int Count()
    {
        if (_pointer == 0)
        {
            return 0;
        }

        return _pointer;
    }

    public string[] GetElements()
    {
        var tmp = _array;
        Array.Reverse(tmp, 0, _pointer);
        return tmp;
    }
}
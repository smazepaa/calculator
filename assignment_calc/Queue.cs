namespace assignment_calc;

public class Queue
{
    
    private static int _capacity = 15;
    private int _pointer;
    private string[] _array = new string[_capacity];


    public void Enqueue(string element)
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

    public string Dequeue()
    {
        var firstElement = _array[0];

        _array[0] = null!;

        if (_pointer != 0)
        {
            for (int i = 0; i < _pointer; i++)
            {
                _array[i] = _array[i + 1];
            }
            
        }
        _pointer--;
        return firstElement;
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
        return _array;
    }
    
   
}

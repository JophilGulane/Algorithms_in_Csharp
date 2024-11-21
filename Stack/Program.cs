namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(10);

            stack.Push(10);
            stack.Push(5);
            stack.Display();
            Console.WriteLine();
            stack.Pop();
            stack.Pop();
            stack.Display();
        }
    }

    public class Stack<T>
    {
        private T[] _elements;
        private int _size;
        private int _capacity;

        public Stack(int capacity)
        {
            _capacity = capacity;
            _elements = new T[_capacity];
            _size = 0;
        }

        public void Push(T element)
        {
            if (_size >= _capacity)
            {
                Console.WriteLine("Stack Overflow!");
                return;
            }
            else
            {
                _elements[_size] = element;
                _size++;
            }
        }

        public T Pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack Underflow!");
                return default;
            }
            else
            {
                _size--;
                _elements[_size] = default;
                return _elements[_size];

            }

        }

        public bool isEmpty()
        {
            return _size <= 0;
        }

        public int Size()
        {

            return _size;
        }

        public void Display()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack is Empty");
                return;
            }
            else
            {
                for (int i = 0; i < _size; i++)
                {
                    Console.Write(_elements[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }


}

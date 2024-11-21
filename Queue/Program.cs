namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


    }

    public class Queue<T>
    {
        private T[] _elements;
        private int _front;
        private int _rear;
        private int _size;
        private int _capacity;

        public Queue(int capacity)
        {
            _capacity = capacity;
            _elements = new T[_capacity];
            _front = 0;
            _rear = 0;
            _size = 0;
        }

        public void Enqueue(T item)
        {
            if (_size >= _capacity)
            {
                Console.WriteLine("Queue Overflow!");
                return;
            }
            _elements[_rear] = item;
            _rear = (_rear + 1) % _capacity;
            _size++;
        }

        public T Dequeue()
        {
            if (_size <= _capacity)
            {
                Console.WriteLine("Queue Underflow!");
                return default;
            }
            else
            {
                T item = _elements[_front];
            }
        }
    }
}

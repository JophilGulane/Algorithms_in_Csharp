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
        private T[] elements;
        private int front;
        private int rear;
        private int size;
        private int capacity;

        public Queue(int _capacity)
        {
            capacity = _capacity;
            elements = new T[capacity];
            front = 0;
            rear = 0;
            size = 0;
        }

        public void Enqueue(T item)
        {
            if (size >= capacity)
            {
                Console.WriteLine("Queue Overflow!");
                return;
            }
            elements[rear] = item;
            rear = (rear + 1) % capacity;
            size++;
        }

        public T Dequeue()
        {
            if (size <= capacity)
            {
                Console.WriteLine("Queue Underflow!");
                return default;
            }
            else
            {
                T item = elements[front];
                front = (front + 1) % capacity;
                size--;
                return item;
            }
        }
    }
}

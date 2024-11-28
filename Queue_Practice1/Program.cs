namespace Queue_Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> myQueue = new Queue<int>(10);
            bool option = true;
            do
            {
                Console.WriteLine("1.Enqueue Element into Stack");
                Console.WriteLine("2.Dequeue Element out of Stack");
                Console.WriteLine("3.Display Elements");
                int userOption = int.Parse(Console.ReadLine());
                switch (userOption)
                {
                    case 1:
                        QueueElement(myQueue);
                        break;
                    case 2:
                        myQueue.Dequeue();
                        break;
                    case 3:
                        myQueue.Display();
                        break;
                    default:
                        break;

                }
            } while (option);
        }

        static void QueueElement(Queue<int> myQueue)
        {
            Console.WriteLine("Enter Element You Want to Enqueue");
            int element = int.Parse(Console.ReadLine());

            myQueue.Enqueue(element);
            Console.WriteLine("Successfully Queue " + element);
        }
    }

    public class Queue<T>
    {
        T[] elements;
        int head;
        int tail;
        int capacity;
        int size;

        public Queue(int capacity)
        {
            this.capacity = capacity;
            elements = new T[capacity];
            head = 0;
            tail = 0;
            size = 0;

        }

        public void Enqueue(T element)
        {
            if (size >= capacity)
            {
                Console.WriteLine("Queue Overflow");
                return;
            }
            elements[tail] = element;
            tail = (tail + 1) % capacity;
            size++;
        }

        public T Dequeue()
        {
            if (size <= 0)
            {
                Console.WriteLine("Queue Underflow");
                return default;
            }
            T element = elements[head];
            elements[head] = default;
            head = (head + 1) % capacity;
            size--;
            return element;
        }

        public void Display()
        {
            foreach (T element in elements)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}

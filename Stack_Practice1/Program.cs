namespace Stack_Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> myStack = new Stack<int>(10);
            bool option = true;
            do
            {
                Console.WriteLine("1.Push Element into Stack");
                Console.WriteLine("2.Pop Element out of Stack");
                Console.WriteLine("3.Display Elements");
                int userOption = int.Parse(Console.ReadLine());
                switch (userOption)
                {
                    case 1:
                        PushElement(myStack);
                        break;
                    case 2:
                        myStack.Pop();
                        break;
                    case 3:
                        myStack.Display();
                        break;
                    default:
                        break;

                }
            } while (option);
        }

        static void PushElement(Stack<int> myStack)
        {
            Console.WriteLine("Enter Element You Want to Push");
            int element = int.Parse(Console.ReadLine());

            myStack.Push(element);
            Console.WriteLine("Successfully Pushed " + element);
        }


    }

    public class Stack<T>
    {
        T[] elements;
        int capacity;
        int size;

        public Stack(int capacity)
        {
            this.capacity = capacity;
            elements = new T[capacity];
            size = 0;
        }

        public void Push(T element)
        {
            if(size > capacity)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            elements[size] = element;
            size++;
        }

        public T Pop()
        {
            if(size <= 0)
            {
                Console.WriteLine("Stack Underflow");
                return default;
            }
            size--;
            elements[size] = default;
            return elements[size];
        }

        public void Display()
        {
            foreach(T element in elements)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}

namespace RecursiveAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(Factorial(5));


            for (int i = 0; i < 5; i++)
            {
                Console.Write(Fibonacci(i) + " ");
            }
            
        }

        static int Factorial(int n)
        {
            if (n == 0) return 1;
            else return n * Factorial(n - 1);
        }

        static int Fibonacci(int n)
        {
            if (n <= 1) return n;
            else return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static int factorial(int n)
        {
            if (n == 0) return 1;
            else return n * factorial(n - 1);
        }

        static int fibonacci(int n)
        {
            if (n <= 1) return n;
            else return fibonacci(n - 1) + fibonacci(n - 2);
        }
    }
}

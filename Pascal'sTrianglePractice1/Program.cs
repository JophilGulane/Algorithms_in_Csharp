namespace Pascal_sTrianglePractice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Pascal(10);
        }

        static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        static int PascalFormula(int n, int k)
        {
            return Factorial(n) / (Factorial(n - k) * Factorial(k));
        }

        static void Pascal(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows - i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k <= i; k++)
                {
                    Console.Write(PascalFormula(i, k) + " ");
                }
                Console.WriteLine();
            }


        }
    }
}

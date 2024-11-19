namespace Pascal_Practice5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pascal(5);
        }

        static int Factorial(int n)
        {
            int result = 1;
            for(int i = 1; i <= n ; i++)
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
            for(int i = 0; i < rows; i ++)
            {
                Console.Write(new string(' ', (rows - i) *2));
                for (int k = 0; k <= i; k++)
                {
                    Console.Write(PascalFormula(i, k) + "   ");
                }
                Console.WriteLine();
            }
            for (int i = rows - 2; i > 0; i--)
            {
                Console.Write(new string(' ', (rows - i)*2));
                for (int k = 0; k <= i; k++)
                {
                    Console.Write(PascalFormula(i, k) + "   ");
                }
                Console.WriteLine();
            }
        }
    }
}

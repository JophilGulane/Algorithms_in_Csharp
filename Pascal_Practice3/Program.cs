using System;

namespace Pascal_Practice3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Diamond-Shaped Pascal’s Triangle:");
            Pascal(5); // Change this value to control the number of rows
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
            // Top half of the diamond
            for (int i = 0; i < rows; i++)
            {
                Console.Write(new string(' ', rows - i));
                for (int k = 0; k <= i; k++)
                {
                    Console.Write(PascalFormula(i, k) + " ");
                }
                Console.WriteLine();
            }

            // Bottom half of the diamond (mirrored by adjusting spaces)
            for (int i = rows - 2; i >= 0; i--)
            {
                // Print spaces at the beginning of each row
                for (int j = 0; j < rows - i; j++)
                {
                    Console.Write(" ");
                }

                // Print the numbers for each row
                for (int k = 0; k <= i; k++)
                {
                    Console.Write(PascalFormula(i, k) + " ");
                }

                // Move to the next line after each row
                Console.Write("\n");
            }

        }
    }
}

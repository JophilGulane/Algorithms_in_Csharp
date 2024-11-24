using System;
using System.Collections.Generic;

namespace MatrixChain_Practice7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of matrices: ");
            int n = int.Parse(Console.ReadLine());
            int[] dimension = new int[n + 1];

            Console.WriteLine("Enter the dimensions of the matrices");
            for (int i = 0; i <= n; i++)
            {
                Console.Write($"Enter the dimensions[{i}]: ");
                dimension[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(MatrixChain(dimension, n + 1));
        }

        static int MatrixChain(int[] dim, int n)
        {
            int[,] m = new int[n, n];
            int[,] s = new int[n, n];


            for (int i = 0; i < n; i++)
            {
                m[i, i] = 0;
            }

            for (int dif = 1; dif < n; dif++)
            {
                for (int i = 1; i < n - dif; i++)
                {
                    int j = i + dif;
                    m[i, j] = int.MaxValue;
                    for (int k = i; k <= j - 1; k++)
                    {
                        int q = m[i, k] + m[k + 1, j] + dim[i - 1] * dim[k] * dim[j];
                        m[i, j] = q;
                        s[i, j] = k;
                    }
                }
            }
            OptimalParen(s, 1, n - 1);
            return m[1, n - 1];

        }

        static void OptimalParen(int[,] s, int i, int j)
        {
            if (i == j)
            {
                Console.Write($"M{i}");
                return;
            }
            Console.Write("(");
            OptimalParen(s, i, s[i, j]);
            OptimalParen(s, s[i, j] + 1, j);
            Console.Write(")");
        }
    }
}

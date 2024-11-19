namespace MatrixChainMultiplication
{
    using System;

    class MatrixChainMultiplication
    {
        public static int MatrixChainOrder(int[] p, int n)
        {
            // Create a 2D array to store the minimum multiplication costs
            int[,] m = new int[n, n];

            // Cost is zero when multiplying one matrix
            for (int i = 1; i < n; i++)
                m[i, i] = 0;

            // diff is the chain length difference
            for (int diff = 1; diff < n - 1; diff++)
            {
                for (int i = 1; i < n - diff; i++)
                {
                    int j = i + diff;
                    m[i, j] = int.MaxValue;

                    // Try all possible positions to place the parenthesis
                    for (int k = i; k <= j - 1; k++)
                    {
                        // Cost of multiplying matrices from i to k and k+1 to j, plus cost of final multiplication
                        int q = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];

                        // Update the minimum cost
                        if (q < m[i, j])
                            m[i, j] = q;
                    }
                }
            }
            DisplayTable(m);

            // Minimum cost to multiply matrices from 1 to n-1
            return m[1, n - 1];
        }

        static void DisplayTable(int[,] table)
        {
            for (int i = 1; i < table.GetLength(0); i++)
            {
                for (int j = 1; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i, j] + " \t");
                }
                Console.WriteLine();
            }
        }

        public static void Main()
        {
            int[] dimensions = { 3, 2, 4, 2, 5 };
            int n = dimensions.Length;

            Console.WriteLine("Minimum number of multiplications is " + MatrixChainOrder(dimensions, n));
        }
    }
}

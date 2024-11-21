namespace MatrixChain_Practice5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dim = { 2, 2, 5, 3, 6, 4, 2 };
            int n = dim.Length;

            Console.WriteLine(MatrixChain(dim, n));
        }

        static int MatrixChain(int[] dim, int n)
        {
            int[,] m = new int[n, n];
            int[,] s = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                m[i, i] = 0;
            }

            for (int dif = 1; dif < n - 1; dif++)
            {
                for (int i = 1; i < n - dif; i++)
                {
                    int j = i + dif;
                    m[i, j] = int.MaxValue;

                    for (int k = 1; k <= j - 1; k++)
                    {
                        int p = m[i, k] + m[k+1, j] + dim[i - 1] * dim[k] * dim[j];
                        m[i, j] = p;
                        s[i, j] = k;
                    }
                }
            }
            PrintOptimalParens(s, 1, n - 1);
            return m[1, n - 1];
        }

        private static void PrintOptimalParens(int[,] s, int i, int j)
        {
            if (i == j)
            {
                Console.Write("A" + i);
            }
            else
            {
                Console.Write("(");
                PrintOptimalParens(s, i, s[i, j]);
                PrintOptimalParens(s, s[i, j] + 1, j);
                Console.Write(")");
            }
        }
    }


}

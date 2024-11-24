namespace MatrixChain_Practice8
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
            string display = DisplayParentheses(s, 1, n - 1);
            Console.WriteLine(display);
            Console.WriteLine();
            return m[1, n - 1];
        } 

        static string DisplayParentheses(int[,] s, int i, int j)
        {
            if (i == j) return $"A{i}";
            int k = s[i, j];
            string left = DisplayParentheses(s, i, k);
            string right = DisplayParentheses(s, k + 1, j);
            return $"({left}{right})";
        }
    }
}

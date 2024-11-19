namespace MatrixChain_Practice4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number of Matrices: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter Dimensions: ");
            int[] dim = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                Console.Write($"Enter Dimension {i}: ");
                dim[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(MatrixChain(dim, n + 1));
        }

        static int MatrixChain(int[] d, int n)
        {
            int[,] m = new int[n, n];

            for(int diff = 1; diff < n - 1; diff++)
            {
                for(int i = 1; i < n - diff; i++)
                {

                    int min = int.MaxValue;
                    int j = i + diff;

                    for (int k = i; k <= j -1 ; k++)
                    {
                        int q = m[i, k] + m[k + 1, j] + d[i - 1] * d[k] * d[j];

                        if (q < min)
                        {
                            min = q;
                        }
                    }
                    m[i, j] = min;      
                }
            }
            return m[1, n - 1];
        }
    }
}

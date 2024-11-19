using System.Reflection;

namespace LCSPractice1
{
    internal class Program
    {
        static void Main(string[] args).
        {
            string X = "logarithm";
            string Y = "algorithm";

            Console.WriteLine(LCS(X, Y));
        }

        static (int, string) LCS(string X, string Y)
        {
            int m = X.Length;
            int n = Y.Length;

            int[,] dp = new int[m + 1, n + 1];

            //Initialize MultiDimensional Array
            for(int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (X[i - 1] == Y[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
                    }
                }
            }

            int lcslength = dp[m, n];

            string lcs = "";
            int x = m;
            int y = n;

            //BackTracking
            while (x > 0 && y > 0)
            {
                if (X[x - 1] == Y[y - 1])
                {
                    lcs = X[x - 1] + lcs;
                    x--;
                    y--;
                }
                else if (dp[x - 1, y] > dp[x, y - 1])
                {
                    x--;
                }

                else
                {
                    y--;
                }
            }
            return (lcslength, lcs);
        }
    }
}

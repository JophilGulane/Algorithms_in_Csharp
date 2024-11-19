using System;

class LCS
{
    static void Main()
    {
        string X = "logarithm";
        string Y = "algorithm";

        var (length, lcs) = FindLCS(X, Y);
        Console.WriteLine("Length of LCS: " + length);
        Console.WriteLine("LCS: " + lcs);
    }
    public static (int, string) FindLCS(string X, string Y)
    {
        int m = X.Length;
        int n = Y.Length;
        int[,] dp = new int[m + 1, n + 1];

        // Fill the dp array
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (X[i - 1] == Y[j - 1])
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        // Length of the LCS
        int lcsLength = dp[m, n];

        // Traceback to find the LCS string
        string lcs = "";
        int x = m, y = n;
        while (x > 0 && y > 0)
        {
            if (X[x - 1] == Y[y - 1])
            {
                lcs = X[x - 1] + lcs;
                x--;
                y--;
            }
            else if (dp[x - 1, y] > dp[x, y - 1])
                x--;
            else
                y--;
        }

        return (lcsLength, lcs);
    }
}
namespace LCS_Practice9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string x = "catcagat"; 
            string y = "cacataga";



            var (llcs, lcs) = LCS(x, y);
            Console.WriteLine($"LLCS: {llcs} LCS: {lcs}");

            string z = "cacataga";
            string e = "catcagat";



            var (llcs1, lcs1) = LCS(z, e);
            Console.WriteLine($"LLCS: {llcs1} LCS: {lcs1}");
        }

        static void DisplayTable(int[,] table)
        {
            for(int i = 0; i < table.GetLength(0); i++)
            {
                for(int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        static (int, string) LCS(string firstString, string secondString)
        {
            int rows = firstString.Length;
            int cols = secondString.Length;
            int[,] table = new int[rows + 1, cols + 1];

            for(int i = 1; i <= rows; i++)
            {
                for(int j = 1; j<= cols; j++)
                {
                    if (firstString[i - 1] == secondString[j - 1])
                    {
                        table[i, j] = table[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        table[i, j] = Math.Max(table[i - 1, j], table[i, j - 1]);
                    }
                }
            }

            DisplayTable(table);
            Console.WriteLine();
            int LLCS = table[rows, cols];
            string LCS = "";
            int x = rows;
            int y = cols;

            while(x > 0 && y > 0)
            {
                if (firstString[x - 1] == secondString[y - 1])
                {
                    LCS = firstString[x - 1] + LCS;
                    x--;
                    y--;
                }
                else if (table[x - 1, y] > table[x, y - 1])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }

            return (LLCS, LCS);

           
        }
    }
}

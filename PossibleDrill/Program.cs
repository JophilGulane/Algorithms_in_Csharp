namespace PossibleDrill
{
    internal class Program
    {
        static Dictionary<char, int> frequency = new Dictionary<char, int>();
        static void Main(string[] args)
        {
            int[] array = { 24, 48, 96, 45 };

            Console.WriteLine(MinMax(array.Length - 1, 0, array));
            Console.WriteLine();





            Console.WriteLine("Enter a string: ");
            string user = Console.ReadLine();

            foreach (char c in user)
            {
                if (frequency.ContainsKey(c))
                {
                    frequency[c]++;
                }
                else
                {
                    frequency[c] = 1;
                }
            }

            var sortedFrequency = frequency.OrderBy(f => f.Key).ToList();

            foreach (var i in frequency)
            {
                Console.WriteLine($"{i.Key} : {i.Value}");
            }








            int[,] A = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] B = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] C;

            int rows = A.GetLength(0);
            int cols = B.GetLength(1);

            C = new int[rows, cols];

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    C[i, j] = 0;
                    for (int k = 0; k < A.GetLength(1); k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(C[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void SumFormula(int[] arr)
        {
            int n = arr.Length + 1;

            int totalSum = n * (n + 1) / 2;

            int arraySum = 0;

            foreach (int num in arr)
            {
                arraySum += num;
            }

            int missingNumber = totalSum - arraySum;


        }
        static (int, int) MinMax(int n, int j, int[] array)
        {
            if (n == 1)
            {
                return (array[j], array[j]);
            }
            if (n == 2)
            {
                return (array[j] < array[j+1] ? (array[j], array[j+1]) : (array[j+1], array[j]));
            }

            else
            {
                var left = MinMax(n / 2, j, array);
                var right = MinMax(n / 2, j + n / 2, array);

                int OverallMin = left.Item1 < right.Item1 ? left.Item1 : right.Item1;
                int OverallMax = left.Item2 > right.Item2 ? left.Item2 : right.Item2;

                return (OverallMin, OverallMax);
            }
        }


        static void PascalTriangle(int row)
        {
            for (int i = 0; i < row; i++) 
            {
                for (int j = 0; j < row - i; j++)
                {
                    Console.Write(" ");
                }

                int number = 1;

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(number + " ");
                    number = number * (i - j) / (j + 1);
                }
                Console.WriteLine();
            }
        }

        static int GCF(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static int LCM(int a, int b) 
        {
            return (a * b) / GCF(a, b);
        }

        static int FindGCF(int[] array)
        {
            int result = array[0];
            for (int i = 1; i < array.Length; i++) 
            {
                result = LCM(result, array[i]);
                if (result == 1) return result;
            }
            return result;
        }
    }
}

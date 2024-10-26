namespace MidtermDrill
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int min = 0;
            int max = 0;
            int[] array = { 25, 6, 10, 8, 9, 3, };
            Min(array, out min);
            Max(array, out max);
            Console.WriteLine(min);
            Console.WriteLine(max);

            InsertionSort(array);

            foreach (int i in array) Console.Write(i + " ");

            int[] numbers = { 15, 25, 10 };
            Console.WriteLine("The LCF is : " + FindLCF(numbers));
        }

        static void Times(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] * array[i + 1];
            }
        }

        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                int temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }

        static void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                int temp = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] < temp)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
        }

        static void Min(int[] array, out int min)
        {
            min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
        }

        static void Max(int[] array, out int max)
        {
            max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
        }


        static int GCF(int a, int b) 
        {
            while (b !=  0)
            {
                int temp = b;
                b = a % b;
                Console.WriteLine("value of b in each iteration: " + b);
                a = temp;
                Console.WriteLine("value of a in each iteration: " + a);
            }
            Console.WriteLine("value of a: " + a);
            return a;
        }

        static int LCF(int a, int b) 
        {
            return a * b / GCF(a, b);
        }

        static int FindLCF(int[] array)
        {
            int result = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                Console.WriteLine($"{result} {array[i]}");
                result = LCF(result, array[i]);
                Console.WriteLine("The LCM: " + result);
            }
            return result;
        }
    }
}

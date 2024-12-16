namespace GCF_Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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

        static int FindGCF(int[] numbers)
        {
            int result = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                result = LCM(result, numbers[i]);
            }
            return result;
        }
    }
}

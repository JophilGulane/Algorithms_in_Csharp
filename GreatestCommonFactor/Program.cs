using System;

class GCFProgram
{
    static void Main()
    {
        int[] numbers = { 24, 48, 96, 45 };
        Console.WriteLine(FindGCF(numbers));
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

    static int FindGCF(int[] numbers)
    {
        int result = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            result = GCF(result, numbers[i]);
        }
        return result;
    }
}
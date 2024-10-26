using System;

class GCFProgram
{
    static void Main()
    {
        int[] numbers = { 24, 48, 96, 45 };
        Console.WriteLine(FindLCM(numbers));
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
        return (a* b) / GCF(a, b);
    }


static int FindLCM(int[] numbers)
{
    int result = numbers[0];

    for (int i = 1; i < numbers.Length; i++)
    {
        result = LCM(result, numbers[i]);
    }
    return result;
}
}
namespace MidtermDrill
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int min = 0;
            int[] array = { 1, 6, 7, 8, 9, 10, }
            Min(array, out min);

            Console.WriteLine(min);
        }

        static void SelectionSort(int[] array)

        static int Min(int[] array, out int min)
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
    }
}

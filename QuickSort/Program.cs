namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int[] array = { 6, 2, 3, 4, 6, 2, 2, 1, 3, 7, 9, 45 };
            int left = 0;
            int right = array.Length - 1;
            QuickSort(array, left, right);

            foreach (int i in array)
            {
                Console.Write(i + " ");

            }
        }

        static void swap(int[] array, int i, int j) 
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        static int partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    swap(array, i, j);
                }
            }

            i++;
            swap(array, i, right);
            return i;
        }

        static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right) return;

            int pivot = partition(array, left, right);

            QuickSort(array, left, pivot - 1);
            QuickSort(array, pivot + 1, right);
        }
    }
}

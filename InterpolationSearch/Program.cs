namespace InterpolationSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            Random random = new Random();

            Console.WriteLine("Enter Array Size: ");
            int size = int.Parse(Console.ReadLine());

            array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 100);
            }

            int value = 5;
            int left = 0;
            int right = array.Length - 1;
            QuickSort(array, left, right);


            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine(InterpolationSearch(array, value)); 
        }

        static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right) return;

            int pivot = partition(array, left, right);
            QuickSort(array, left, pivot - 1);
            QuickSort(array, pivot + 1, right);
        }

        static int partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    swap(array, i , j);
                    i++;
                }
            }

            swap(array, i, right);

            return i;
        }

        static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static int InterpolationSearch(int[] array, int value)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int probe = low + (high - low) * (value - array[low]) / (array[high] - array[low]);

                if (array[probe] == value)
                {
                    return probe;
                }
                else if (array[probe] < value)
                {
                    low = probe + 1;
                }
                else 
                {
                    high = probe - 1;
                }
            }
            return -1;
        }
    }
}

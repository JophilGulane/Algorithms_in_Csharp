namespace HeapSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 8, 5, 6, 4, 3, 7, 2, 1, 9, 0 };

            HeapSort(array);

            Console.WriteLine("Sorted array:");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        static void HeapSort(int[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            } 
            
            for (int i = n - 1; i > 0; i--)
            {
                swap(array, 0, i);

                Heapify(array, i, 0);
            }
        }

        static void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
            {
                largest = left;     
            }

            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                swap(array, i, largest);

                Heapify(array, n, largest);
            }
        }

        static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }


}

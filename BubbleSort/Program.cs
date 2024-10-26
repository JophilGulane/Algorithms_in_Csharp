namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.Write("Enter Array Size: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1,20);
            }
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            MergeSort(array);

            foreach (int i in array)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine(LinearSearch(array, 5));
        }

        static void BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    } 
                }
            }
        }

        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1;  j < array.Length; j++)
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
            for (int i = 0; i  <= array.Length - 1; i++)
            {
                int temp = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j --;
                }
                array[j + 1] = temp;
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
            int i = left;
            for (int j = left; j <= right; j++)
            {
                if (array[j] < pivot)
                {
                    swap(array, i, j);
                    i++;
                }
            }
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

        static void MergeSort(int[] array)
        {
            int length = array.Length;

            if (length <= 1) return;

            int mid = length / 2;

            int[] leftArray = new int[mid];
            int[] rightArray = new int[length - mid];

            int j = 0;

            for (int i = 0; i < length; i++)
            {
                if (i < mid)
                {
                    leftArray[i] = array[i];

                }
                else
                {
                    rightArray[j] = array[i];
                    j++;
                }
            }
            MergeSort(leftArray);
            MergeSort(rightArray);
            merge(leftArray, rightArray, array);

        }

        static void merge(int[] leftArray, int[] rightArray, int[] array)
        {
            int leftSize = array.Length / 2;
            int rightSize = array.Length - leftSize;

            int i = 0;
            int l = 0;
            int r = 0;

            while (l < leftSize && r < rightSize)
            {
                if (leftArray[l] < rightArray[r])
                {
                    array[i] = leftArray[l];
                    i++;
                    l++;
                }
                else
                {
                    array[i] = rightArray[r];
                    i++;
                    r++;
                }
            }

            while (l < leftSize)
            {
                array[i] = leftArray[l];
                i++;
                l++;
            }

            while (r < rightSize)
            {
                array[i] = rightArray[r];
                i++;
                r++;
            }
        }

        static int LinearSearch(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target) return i;
            }
            return -1;
        }

    }
}

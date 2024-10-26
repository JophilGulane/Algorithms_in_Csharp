namespace SearchingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int size = 20;
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(10, 20);
            }

            MergeSort(array);

            foreach (int i in array)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine(QuickSelect(array, 0, array.Length - 1, 15));
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

            for (int j = left; j < right; j++)
            {
                swap(array, i, j);
                i++;
            }
            swap(array, i, right);
            return i;
        }

        static int QuickSelect(int[] array, int left, int right, int k)
        {
            int pivot = partition(array, left, right);

            if (pivot == k - 1)
            {
                return array[pivot];
            }

            if (pivot > k - 1)
            {
                return QuickSelect(array, left, pivot - 1, k);
            }
            else
            {
                return QuickSelect(array, pivot + 1, right, k);
            }
        }

        static int InterpolationSearch(int[] array, int value)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int probe = low + (high - low) * (value - array[low]) / (array[high] - array[low]);

                if (array[probe] == value) return probe;

                if (array[probe] < value)
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

            static int BinarySearch(int[] array, int target)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (array[mid] == target) return mid;

                if (array[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }

        static int LinearSearch(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target) return i;
            }
            return -1;
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


    }
}

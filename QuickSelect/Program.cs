namespace QuickSelect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array;

            Console.Write("Enter size of Array: ");
            int size = int.Parse(Console.ReadLine());

            array = new int[size];

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1,20);
            }

            foreach (int i in array)
            {
                Console.Write(i+ " ");
            }

            int left = 0;
            int right = array.Length - 1;
            int k = 3;
            int target = quick_select(array,left,right, (right + 1) - k);

            Console.WriteLine($"The {k} number is {target}");
        }

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    Swap(array, i, j);
                    i++;
                }
            }
            Swap(array, i, right);
            return i;
        }

        static int quick_select(int[] array, int left, int right, int k)
        {
            int pivot = Partition(array, left, right);

            if (pivot == k - 1)
            {
                return array[pivot];    
            }

            if (pivot > k - 1)
            {
                return quick_select(array, left, pivot - 1, k);
            }

            else
            {
                return quick_select(array,pivot + 1, right, k);
            }
        }
    }
}

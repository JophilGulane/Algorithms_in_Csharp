namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrNumbers;

            Random r = new Random();

            Console.WriteLine("Enter Size: ");
            int size = int.Parse(Console.ReadLine());

            arrNumbers = new int[size];

            for (int i = 0; i < size; i++)
            {
                arrNumbers[i] = r.Next(1, 10);
            }
            InsertionSort(arrNumbers);
            foreach (int i in arrNumbers)
            {
                Console.Write(i + " ");
            }

            int index = BinarySearch(arrNumbers, 7);

            if (index == -1)
            {
                Console.WriteLine("Target not found");
            }
            else
            {
                Console.WriteLine("Target is at" + index);
            }


        }

        static void InsertionSort(int[] arrNumbers)
        {
            for (int i = 0; i < arrNumbers.Length; i++)
            {
                int temp = arrNumbers[i];
                int j = i - 1;
                while (j >= 0 && arrNumbers[j] > temp)
                {
                    arrNumbers[j + 1] = arrNumbers[j];
                    j--;
                }
                arrNumbers[j + 1] = temp;
            }
        }

        static int BinarySearch(int[] array, int target) 
        {
            int low = 0;
            int high = array.Length - 1;

            while ( low <= high)
            {
                int mid = low + (high - low) / 2;
                int value = array[mid];

                if (value < target)
                {
                    low = mid + 1;
                }

                else if ( value > target)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;

        }
    }
}

namespace QuickSelectPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();

            int size = 20;
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rd.Next(0, 100);
            }
            SelectionSort(array);
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();



            Console.Write("Find the kth largest element: ");
            int k = int.Parse(Console.ReadLine());
            int n = array.Length - 1;

            int qs = QuickSelect(array, 0, n, (array.Length + 1) - k);

            Console.WriteLine("Target is: " + qs);
        }

        static void InsertionSort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int temp = a[i];
                int j = i - 1;

                while (j >= 0 && a[j] > temp)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = temp;
            }
        }

        static void SelectionSort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int min = i;
                for (int j = i; j < a.Length; j++)
                {
                    if (a[j] < a[min])
                    {
                        min = j;
                    }
                }
                swap(a, min, i);

            }
        }

        static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static int partition(int[] a, int l, int r)
        {
            int pivot = a[r];
            int i = l;

            for (int j = l; j < r; j++)
            {
                if (a[j] < pivot)
                {
                    swap(a, i, j);
                    i++;
                }
            }
            swap(a, i, r);
            return i;
    
        }   

        static int QuickSelect(int[] a, int l, int r, int k)
        {   
            int pivot = partition(a, l, r);



            if (k - 1 == pivot)
            {
                return a[pivot];
            }

            if (k > pivot)
            {
                return QuickSelect(a, pivot + 1, r, k);
            }

            else
            {
                return QuickSelect(a, l, pivot - 1, k);
            }
        }
    }

        
}

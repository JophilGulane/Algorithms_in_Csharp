using System.Diagnostics;
using System.Drawing;

namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random  = new Random();



            ArrayC array = new ArrayC(20);

            for (int i = 0; i < array.length; i++)
            {
                array.Add(random.Next(10, 90));
            }
            int[] array_num = { 8, 4, 5, 6, 1, 23, 5, 7, 123, 6, 64, 12 };
            Stopwatch sw = new Stopwatch();

            sw.Start();
            MergeSort(array_num);
            sw.Stop();
            Console.WriteLine("Time taken {0} ms", sw.ElapsedMilliseconds);

            sw.Restart();
            
            foreach (int num in array_num)
            {
                Console.Write(num + " ");
            }
            sw.Stop();
            Console.WriteLine("Time taken {0} ms", sw.ElapsedMilliseconds);
        }

        static void MergeSort(int[] array)
        {
            int length = array.Length;
            if (length <= 1) return;

            int middle = length / 2;

            int[] leftArray = new int[middle];
            int[] rightArray = new int[length - middle];

            int i = 0;
            int j = 0;

            for (; i < length; i++)
            {
                if (i < middle)
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

    public class ArrayC
    {
        public int[] array;
        private int activeIndex = 0;
        public int length;

        public ArrayC(int size)
        {
            array = new int[size];
            size = length;
        }

        public void Add(int value)
        {
            array[activeIndex] = value;
            activeIndex++;
        }

        public void Display()
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");

            }
            Console.WriteLine();
        }
    }
}

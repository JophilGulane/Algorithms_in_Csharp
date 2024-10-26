

namespace Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            dCollection myNum = new dCollection(1000);

            for (int i = 0; i <= myNum.end; i++)
            {
                myNum.AddElement(random.Next(1,10000));
            }

            Console.WriteLine("UNSORTED");
            myNum.DisplayArray();
            Console.WriteLine("UNSORTED");

            Console.WriteLine("Sorted");
            myNum.InsertionSort();
            myNum.DisplayArray();
            Console.WriteLine("Sorted");
        }
    }

    class dCollection
    {
        private int[] array;
        private int activeIndex;
        public int end;


        public dCollection(int size)
        {
            array = new int[size];
            activeIndex = 0;
            end = size - 1;
        }

        public void AddElement(int element)
        {
            array[activeIndex] = element;
            activeIndex++;
        }

        public void DisplayArray()
        {
            foreach (int element in array)
            {
                Console.Write($"{element} ");
            }
        }

        public void SelectionSort()
        {
            for (int i = 0; i <= end; i++)
            {
                int min = i;
                for (int j = i; j <= end; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                int temp = array[min];
                array[min] = array[i];
                array[i] = temp;
            }
        }

        public void InsertionSort()
        {
            for (int i = 1; i <= end; i++)
            {
                int temp = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
        }
    }
}

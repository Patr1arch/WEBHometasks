using System;

namespace WEBHometask1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Length of array");
            int lenght = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input min el in this array");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input max el in this array");
            int max = Convert.ToInt32(Console.ReadLine());

            if (max < min) (max, min) = (min, max);

            var rand = new Random();
            int[] array = new int[lenght];

            for (var i = 0; i < lenght; i++)
            {
                array[i] = rand.Next(min, max);
            }

            Console.WriteLine("How do you want to sort an array? Press '>' if you want to sort descending or '<' if you want to sort ascending");
            char symbol = Convert.ToChar(Console.ReadLine());
            switch (symbol)
            {
                case '>':
                    array = SelectionAscending(array);
                    break;
                case '<':
                    array = SelectionDescending(array);
                    break;
            }

            Console.WriteLine("Array: ");
            for (var i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.ReadKey();
        }

        public static int[] SelectionAscending(int[] list)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                int dummy = list[i];
                list[i] = list[min];
                list[min] = dummy;
            }
            return list;
        }

        public static int[] SelectionDescending(int[] list)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[j] > list[max])
                    {
                        max = j;
                    }
                }
                int dummy = list[i];
                list[i] = list[max];
                list[max] = dummy;
            }
            return list;
        }
    }
}

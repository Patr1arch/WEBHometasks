using System;

namespace WEBHometask1_3
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

            Console.WriteLine("Array: ");
            for (var i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.ReadKey();
        }
    }
}

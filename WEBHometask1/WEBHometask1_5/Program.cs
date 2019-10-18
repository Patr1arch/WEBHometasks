using System;

namespace WEBHometask1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose formula: ");
            Console.WriteLine("0: ((1 + m * x) ^ n - (1 + n * x) ^ m) / (x ^ 2)");
            Console.WriteLine("1: ((x - sqrt(x ^ 2 - 1) ) ^ n + (x + sqrt(x ^ 2 - 1)) ^ n) / x ^ n");

            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 0:
                    Console.WriteLine("Choose x: ");
                    double x = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Choose m > 0 and natural: ");
                    int m = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Choose n > 0 and natural: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine((Math.Pow(1 + m * x, n) - Math.Pow(1 + n * x, m)) / Math.Pow(x, 2));
                    break;
                case 1:
                    Console.WriteLine("Choose x: ");
                    x = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Choose n > 0 and natural: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine( Math.Round((Math.Pow(x - Math.Sqrt(Math.Pow(x, 2) - 1), n) + Math.Pow(x + Math.Sqrt(Math.Pow(x, 2) - 1), n)) / Math.Pow(x, n), 2) );
                    break;
            }

            Console.ReadKey();
        }
    }
}

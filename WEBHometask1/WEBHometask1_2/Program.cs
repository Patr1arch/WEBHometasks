using System;

namespace WEBHometask1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                bool isGood = true;
                Console.WriteLine("Input an operation");
                string ar_op_s = Console.ReadLine();
                if ((ar_op_s.Length != 1) || (ar_op_s[0] != '+' && ar_op_s[0] != '-' && ar_op_s[0] != '*' && ar_op_s[0] != '/'))
                {
                    Console.WriteLine("Error! It's not a current operand!");
                    isGood = false;
                }

                if (isGood)
                {
                    char ar_op = ar_op_s[0];

                    Console.WriteLine("Input two operands in two lines");

                    string a_s = Console.ReadLine();
                    double a;

                    if (!double.TryParse(a_s, out a))
                    {
                        Console.WriteLine("Error! First argument is't a number");
                        isGood = false;
                    }

                    string b_s = Console.ReadLine();
                    double b;

                    if (!double.TryParse(b_s, out b))
                    {
                        Console.WriteLine("Error! Argument is't a number");
                        isGood = false;
                    }

                    if (isGood)
                    {
                        switch (ar_op)
                        {
                            case '+':
                                Console.WriteLine("Result: {0}", a + b);
                                break;
                            case '-':
                                Console.WriteLine("Result: {0}", a - b);
                                break;
                            case '*':
                                Console.WriteLine("Result: {0}", a * b);
                                break;
                            case '/':
                                if (b == 0)
                                {
                                    Console.WriteLine("Error! Division by zero");
                                    break;
                                }
                                Console.WriteLine("Result: {0}", a / b);
                                break;
                        }
                    }
                }
                Console.WriteLine("Would you like to continue? Press 'exit' to exit");
            } while (Console.ReadLine() != "exit");
            
        }
    }
}

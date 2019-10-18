using System;

namespace WEBHometask1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a text: ");
            string test = Console.ReadLine();

            int wordCount = 0;
            int noSpaceSymbols = 0;
            string wordOfLastSym = "";
            bool isWord = false;

            for (var i = 0; i < test.Length; i++)
            {
                if (test[i] != ' ') noSpaceSymbols++;

                if (char.IsLetter(test[i])) 
                {
                    isWord = true;
                }
                else if (isWord && test[i] == '-' && char.IsLetter(test[i - 1]) && i < test.Length - 1 && char.IsLetter(test[i + 1]))
                {

                }
                else if (isWord)
                {
                    isWord = false;
                    wordCount++;
                    wordOfLastSym += i > 0 ? test[i - 1].ToString() : "";
                }
            }

            if (char.IsLetter(test[test.Length - 1]) && isWord)
            {
                wordCount++;
                wordOfLastSym += test[test.Length - 1].ToString();
            }

            Console.WriteLine("Количество слов: {0};", wordCount);
            Console.WriteLine("Количество символов без пробелов: {0};", noSpaceSymbols);
            Console.WriteLine("Соотношение количество символов без пробелов к количеству слов: {0};", wordCount == 0 ? 0 : Math.Round((double)noSpaceSymbols / wordCount, 2));
            Console.WriteLine("Слово из последних символов слов: {0};", wordOfLastSym);

            Console.ReadKey();

        } 
    }
}

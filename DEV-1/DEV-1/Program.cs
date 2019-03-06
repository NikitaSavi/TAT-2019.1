using System;
/// <summary>
/// DEV-1 Task: вводится строка (2+ символов), выводятся в консоль все подпоследовательности (2+ символов), в которых нет двух последовательных повторяющихся символов,
///поиск подстрок идёт в отдельном классе[Subseq_search]
/// </summary>

namespace DEV_1
{
    class Program
    {
        static void Main(string[] args) //строка передаётся через консоль как аргумент
        {
            if (args.Length == 0 )
            {
                Console.WriteLine("No arguments recieved. Enter a line with at least 2 characters.");
            }
            else
            {
                string line = null;

                {//из нескольких аргументов собирается одна строка
                    foreach (string i in args)
                    {
                        line += i + " ";
                    }
                    line = line.TrimEnd();
                }

                if (line.Length < 2)
                {
                    Console.WriteLine("At least 2 characters are required");
                }
                else
                {
                    Console.WriteLine("Your line is: " + line);
                    Subseq_search subseq_search = new Subseq_search();
                    subseq_search.Search(line);   //запуск операции
                }
            }

            Console.ReadKey();
        }
    }
}

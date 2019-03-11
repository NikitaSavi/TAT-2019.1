using System;

namespace DEV_1
{
    class Subseq_search
    {
        public void Search(string line)
        {
            string seq_out = string.Empty;      //сюда пишутся подпослед. для печати

            for (int i = 0; i < line.Length - 1; i++)    //i - индекс первого элемента подпосл., j - индекс след.символов в подпосл.
            {//обход всей строки, берём символ i и выписываем все подходящие подпоследовательности, начинающиеся с него
                seq_out += line[i];

                for (int j = i + 1; j < line.Length; j++)
                {
                    seq_out += line[j];          //взяли следующий символ и добавили в строку на вывод
                    if (line[j] != line[j - 1])
                    {//если данный и предыдущий символ не повторяются, выводим на печать, дописываем след.символ; иначе начинаем искать послед., начинающиеся уже со след.элемента
                        Console.WriteLine(seq_out);
                    }
                    else break;
                }

                seq_out = null;
            }
        }
    }
}

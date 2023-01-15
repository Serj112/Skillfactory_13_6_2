using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //Редактируем текст
        string text = File.ReadAllText(@"C:\Users\Toshka\Desktop\Text1.txt");
        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        //Создаем сортированный словарь для 10 наиболее встречающихся слов
        Dictionary<string, int> sd = new Dictionary<string, int>();

        //Создаем массив для работы с каждым словом м последующим подсчетом
        string[] words = noPunctuationText.Split();

        //Проверяем наличие того или иного слова в словаре (если нет, начинаем подсчет; если есть, прибавляем к счетчику
        foreach (string word in words)
        {
            if (sd.ContainsKey(word))
                sd[word] ++;  
            
            else           
                sd.Add(word, 1);           
        }

        //Отбираем 10 слов и отображаем их (цикл ломается на 11-ом элементе, потому что первая запись отобразит кол-во пробелов)
        int k = 0;
        foreach (KeyValuePair<string, int> p in sd.OrderByDescending(x => x.Value))
        {
            k++;
            Console.WriteLine($"Слово {p.Key} встречается {p.Value} раз");
            if (k == 11) break;
        } 
    }
}
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Journal journal = Input();
            journal.Output();

            string filename = "journal.json";
            SaveToFile(journal, filename);

            Journal loadedJournal = LoadFromFile(filename);
            loadedJournal.Output();
        }
        static Journal Input()
        {
            Journal journal = new Journal();
            Console.Write("Введите название журнала: ");
            journal.Title = Console.ReadLine();
            Console.Write("Введите название издательства: ");
            journal.Publisher = Console.ReadLine();
            Console.Write("Введите дату издания: ");
            journal.Date = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите количество страниц: ");
            journal.PageCount = int.Parse(Console.ReadLine());
            journal.Articles = new List<Article>();
            Console.Write("Сколько статей в журнале:");
            int articleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < articleCount; i++)
            {
                Article article = new Article();
                Console.Write($"Введите название статьи {i + 1}: ");
                article.Title = Console.ReadLine();
                Console.Write($"Введите количество символов в статье {i + 1}: ");
                article.CharCount = int.Parse(Console.ReadLine());
                Console.Write($"Введите анонс статьи {i + 1}: ");
                article.Summary = Console.ReadLine();
                journal.Articles.Add(article);
            }
            return journal;
        }
        static void SaveToFile(Journal journal, string filePath)
        {
            string json = JsonSerializer.Serialize(journal);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Журнал сохранён в файл: {filePath}");
        }
        static Journal LoadFromFile(string filename)
        {
            string json = File.ReadAllText(filename);
            Journal journal = JsonSerializer.Deserialize<Journal>(json);
            Console.WriteLine($"Журнал загружен из файла: {filename}");
            return journal;
        }
    }
}
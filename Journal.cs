using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp12
{
    internal class Journal
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime Date { get; set; }
        public int PageCount { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();

        public void Output()
        {
            Console.WriteLine($"Название журнала: {Title},Издательство: {Publisher},Дата издания: {Date.ToShortDateString()},Количество страниц: {PageCount} \n\nСтатьи:");
            foreach (var a in Articles)
            {
                Console.WriteLine($"Название: {a.Title},Количество символов: {a.CharCount},Анонс: {a.Summary}");
                Console.WriteLine();
            }
        }

    }
}

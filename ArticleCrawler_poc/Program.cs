using ArticleCrawler_poc.Objects;
using HtmlAgilityPack;
using System;
using System.Linq;

namespace ArticleCrawler_poc
{
    public delegate void SimpleDelegate();
    class Program
    {
        static event SimpleDelegate OnBeforeQuit;
        static event SimpleDelegate OnQuit;

        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            crawler.StartCrawling(100);
            BeforeQuit();
        }

        private static void Test()
        {
            Console.WriteLine("Please enter your name so we can say hi");
            var yourWonderFullName = Console.ReadLine();
            Console.WriteLine($"Hi {yourWonderFullName}, you glorious Basterd");
        }

        private static void BeforeQuit()
        {
            OnBeforeQuit?.Invoke();
            Console.WriteLine("Press a key to complete...");
            Console.ReadKey();
            OnQuit?.Invoke();
        }
    }
}

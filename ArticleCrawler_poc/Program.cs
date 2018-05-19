using System;

namespace ArticleCrawler_poc
{
    public delegate void SimpleDelegate();
    class Program
    {
        static event SimpleDelegate OnBeforeQuit;
        static event SimpleDelegate OnQuit;

        static void Main(string[] args)
        {


            BeforeQuit();
        }

        private static void BeforeQuit()
        {
            OnBeforeQuit();
            Console.WriteLine("Press enter to complete...");
            Console.ReadLine();
            OnQuit();
        }
    }
}

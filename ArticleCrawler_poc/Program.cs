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

            OnBeforeQuit += Test;
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

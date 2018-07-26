using System;
using System.Threading;

namespace SharedResources
{
    class Program
    {
        private static bool isCompleted = false;

        private static readonly object lockCompleted = new object();

        static void Main(string[] args)
        {
            Thread thread = new Thread(HelloWorld);

            // Worker Thread
            thread.Start();
            
            // Main Thread
            HelloWorld();

            Console.ReadLine();
        }

        private static void HelloWorld()
        {
            lock (lockCompleted)
            {
                if (!isCompleted)
                {
                    Console.WriteLine("Hello world should print only once.");

                    isCompleted = true;
                }
            }
        }
    }
}

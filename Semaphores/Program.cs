using System;
using System.Threading;

namespace Semaphores
{
    class Program
    {
        // Only allow 3 concurrent threads to access a certail resource
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3);

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                new Thread(EnterSemaphore).Start(i+1);
            }

            Console.ReadLine();
        }

        private static void EnterSemaphore(object id)
        {
            Console.WriteLine($"Thread {id} is waiting to be part of the club.");
            semaphoreSlim.Wait();
            Console.WriteLine($"Thread {id} is part of the club.");
            Thread.Sleep(1000 / (int)id);
            Console.WriteLine($"Thread {id} left the club.");
        }
    }
}

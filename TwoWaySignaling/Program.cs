using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwoWaySignaling
{
    class Program
    {
        static EventWaitHandle first = new AutoResetEvent(false);

        static EventWaitHandle second = new AutoResetEvent(false);

        static readonly object customLock = new object();

        static string value = string.Empty;

        static void Main(string[] args)
        {
            Task.Factory.StartNew(WorkerThread);

            Console.WriteLine("Main thread is waiting...");

            first.WaitOne();

            lock(customLock)
            {
                value = "Updating the value inside the main thread";

                Console.WriteLine(value);
            }

            Thread.Sleep(1000);

            second.Set(); // we want the worker thread to have the .WaitOne

            Console.WriteLine("Released worker thread.");

            Console.ReadLine();
        }

        private static void WorkerThread()
        {
            Thread.Sleep(1000);

            lock (customLock)
            {
                value = "Updating the value inside the worker thread.";

                Console.WriteLine(value);
            }

            first.Set();

            Console.WriteLine("Released main thread.");

            Console.WriteLine("Worker thread is waiting...");

            second.WaitOne();
        }
    }
}
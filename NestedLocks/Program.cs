using System;
using System.Threading;
using System.Threading.Tasks;

namespace NestedLocks
{
    class Program
    {
        static readonly object customLock = new object();
        static void Main(string[] args)
        {
            // Here the parent lock is the one that only matters.
            // It holds the lock on that particular resource 
            // no matter how many other locks are going down the execution.
            lock (customLock)
            {
                DoSomething();
            }

            Console.ReadLine();
        }

        private static void DoSomething()
        {
            lock(customLock)
            {
                Thread.Sleep(3000);

                AnotherMethod();
            }
        }

        private static void AnotherMethod()
        {
            lock (customLock)
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
}

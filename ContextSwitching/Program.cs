using System;
using System.Threading;

namespace ContextSwitching
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is a worker thread
            Thread thread = new Thread(WriteUsingNewThread);

            thread.Name = "Custom Worker Thread";

            // thread.Start(): 
            // Our way of letting CLR know that it needs to talk to the Thread Scheduler 
            // to spawn off a new thread
            thread.Start();

            // This is the main thread
            Thread.CurrentThread.Name = "Customized Main Thread";

            for (int i = 0; i < 1000; i++)
            {
                Console.Write($" A{i} ");
            }

            Console.ReadLine();
        }

        private static void WriteUsingNewThread()
        {
            for(int i=0; i<1000; i++)
            {
                Console.Write($" Z{i} ");
            }
        }
    }
}

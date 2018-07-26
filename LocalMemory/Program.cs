using System;
using System.Threading;

namespace LocalMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Worker Thread
            new Thread(PrintOneToThirty).Start();

            // Main Thread
            PrintOneToThirty();

            Console.ReadLine();
        }

        private static void PrintOneToThirty()
        {
            // This variable i will be part of the local memory allocated for each thread
            for(int i=0; i<30; i++)
            {
                Console.Write($"{i+1} ");
            }
        }
    }
}

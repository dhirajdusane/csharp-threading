using System;
using System.Threading;
using System.Threading.Tasks;

namespace ManualResetEventForSignaling
{
    class Program
    {
        // Two ways also for manual reset events
        static ManualResetEvent waitHandle = new ManualResetEvent(false);

        //static EventWaitHandle waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);

        static void Main(string[] args)
        {
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);

            Thread.Sleep(1000);

            Console.WriteLine("Press a key to release all the threads so far.");

            Console.ReadKey();

            waitHandle.Set();

            Thread.Sleep(1000);

            Console.WriteLine("Press a key again. Threads won't block even if they call WaitOne.");

            Console.ReadKey();

            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);

            Thread.Sleep(1000);

            Console.WriteLine("Press a key again. Threads will block if they call WaitOne.");

            Console.ReadKey();

            // To stop the above behavior of not blocking we have to explicitly call Reset() 
            // in the case of a manual reset event. In automatic when we call Set() then
            // Reset() also gets called under the hood.
            waitHandle.Reset();

            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);

            Thread.Sleep(1000);

            Console.WriteLine("Press a key again. Calls Set().");

            Console.ReadKey();

            waitHandle.Set();

            Console.ReadLine();
        }

        private static void CallWaitOne()
        {
            Console.WriteLine(Task.CurrentId + " has called WaitOne.");

            waitHandle.WaitOne();

            Console.WriteLine(Task.CurrentId + " finally ended.");
        }
    }
}

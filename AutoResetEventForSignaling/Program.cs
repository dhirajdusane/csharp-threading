using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutoResetEventForSignaling
{
    class Program
    {
        // Two ways of instantiating an AutoReset event
        //static EventWaitHandle autoResetEvent = new EventWaitHandle(false, EventResetMode.AutoReset);

        static AutoResetEvent eventWaitHandle = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Task.Factory.StartNew(WorkerThread);

            Thread.Sleep(2500);

            eventWaitHandle.Set();

            Console.ReadLine();
        }

        private static void WorkerThread()
        {
            Console.WriteLine("Waiting to enter the gate.");

            eventWaitHandle.WaitOne();

            // Logic - It will not be executed until the UI thread calls .Set() signal
            // on the eventWaitHandle to release this worker thread
            Console.WriteLine("Gate entered.");
        }
    }
}

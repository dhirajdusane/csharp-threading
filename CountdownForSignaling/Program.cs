using System;
using System.Threading;
using System.Threading.Tasks;

namespace CountdownForSignaling
{
    class Program
    {
        static CountdownEvent countdownEvent = new CountdownEvent(5);

        static void Main(string[] args)
        {
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);

            countdownEvent.Wait();

            Console.WriteLine("Signal has been called 5 times.");

            Console.ReadLine();
        }

        private static void DoSomething()
        {
            Thread.Sleep(250);

            Console.WriteLine(Task.CurrentId + " is calling signal.");

            countdownEvent.Signal();
        }
    }
}

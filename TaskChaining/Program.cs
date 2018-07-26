using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskChaining
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> antecedent = Task.Run(() => {
                Thread.Sleep(2000);
                return DateTime.Today.ToShortDateString();
            });

            // We want here to pass the antecedent data to the continuation
            Task<string> continuation = antecedent.ContinueWith(x => {
                return "Today is " + antecedent.Result;
            });

            Console.WriteLine("This will display before the result.");

            Console.WriteLine(continuation.Result);

            Console.ReadLine();
        }
    }
}

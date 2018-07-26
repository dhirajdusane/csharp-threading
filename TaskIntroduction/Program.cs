using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(SimpleMethod);
            task.Start();

            Task<string> taskThatReturnsValue = new Task<string>(MethodThatReturnsValue);
            taskThatReturnsValue.Start();
            taskThatReturnsValue.Wait();

            Console.WriteLine(taskThatReturnsValue.Result);

            Console.ReadLine();
        }

        private static string MethodThatReturnsValue()
        {
            // This simulates a computational intensive operation
            Thread.Sleep(2000);

            return "Hello";
        }

        private static void SimpleMethod()
        {
            Console.WriteLine("Hello World");
        }
    }
}

using System;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Is main thread a thread pool thread?
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

            Employee employee = new Employee
            {
                Name = "Orestis",
                CompanyName = "Microsoft"
            };

            ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayEmployeeInfo), employee);

            // Set the max number of threads in the thread pool - 1st way
            // Get the number of processors in the host machine 
            //var processorsCount = Environment.ProcessorCount;

            //ThreadPool.SetMaxThreads(processorsCount * 2, processorsCount * 2);

            // Set the max number of threads in the thread pool - 2nd way
            int workerThreads = 0;
            int completionPortThreads = 0;
            ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);

            ThreadPool.SetMaxThreads(workerThreads * 2, completionPortThreads * 2);

            // Is main thread a thread pool thread?
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

            Console.ReadLine();
        }

        private static void DisplayEmployeeInfo(object employee)
        {
            // Is this indeed a thread pool thread?
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

            Employee emp = employee as Employee;

            Console.WriteLine($"Person name is: {emp.Name} and company name is: {emp.CompanyName}");
        }

        public class Employee
        {
            public string Name { get; set; }

            public string CompanyName { get; set; }
        }
    }
}
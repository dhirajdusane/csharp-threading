using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCompletionSource
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskCompletionSource<Product> taskCompletionSource = new TaskCompletionSource<Product>();

            Task<Product> lazyTask = taskCompletionSource.Task;

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);

                taskCompletionSource.SetResult(new Product
                {
                    Id = 1,
                    Model = "Test Product"
                });
            });

            Task.Factory.StartNew(() =>
            {
                if(Console.ReadKey().KeyChar == 'x')
                {
                    Product result = lazyTask.Result;

                    Console.WriteLine("\n Result is: " + result.Model);
                }
            });

            Thread.Sleep(5000);
            
            Console.ReadLine();
        }
    }
}

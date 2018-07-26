using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(0, 10000000).ToArray();

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancellationTokenSource.Token;
            parallelOptions.MaxDegreeOfParallelism = Environment.ProcessorCount;

            Console.WriteLine("Press 'x' to cancel.");

            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar == 'x')
                {
                    cancellationTokenSource.Cancel();
                }
            });

            long total = 0;

            try
            {
                Parallel.For<long>(0, list.Length, parallelOptions, () => 0, (count, parallelLoopState, subtotal) =>
                {
                    //Thread.Sleep(200);

                    parallelOptions.CancellationToken.ThrowIfCancellationRequested();

                    subtotal += list[count];

                    return subtotal;
                }, 
                (x) =>
                {
                    Console.WriteLine(Interlocked.Add(ref total, x));
                });
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Cancelled " + ex.Message);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }

            Console.WriteLine("The final sum is: " + total);

            Console.ReadLine();
        }
    }
}

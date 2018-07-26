using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TaskParallelLibraryIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Time taken for sequential execution is: " + stopwatch.ElapsedMilliseconds);

            stopwatch.Stop();

            stopwatch.Start();

            Parallel.For(0, 10, i =>
            {
                Console.WriteLine(i);
            });

            Console.WriteLine("Time taken for parallel execution is: " + stopwatch.ElapsedMilliseconds);

            Console.ReadLine();
        }
    }
}

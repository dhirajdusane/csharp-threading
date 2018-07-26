using System;
using System.Collections.Concurrent;
using System.Linq;

namespace PLinqForAllStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(2000, 5000);

            var query = list
                            .AsParallel()
                            .Where(n => n % 25 == 0);

            ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();

            query.ForAll(x => concurrentBag.Add(x));

            Console.WriteLine(concurrentBag.Count());

            Console.ReadLine();
        }
    }
}

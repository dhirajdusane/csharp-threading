using System;
using System.Linq;

namespace ParallelLinqIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 100000);

            var primeNumbers = list.AsParallel().Where(IsPrime());

            Console.WriteLine($"Prime numbers found: {primeNumbers.Count()}");

            Console.ReadLine();
        }

        private static Func<int, bool> IsPrime()
        {
            return x =>
            {
                if (x == 1) return false;

                if (x == 2) return true;

                if (x % 2 == 0) return false;

                var boundary = (int)Math.Floor(Math.Sqrt(x));

                for (int i = 3; i < boundary; i += 2)
                {
                    if (x % i == 0) return false;
                }

                return true;
            };
        }
    }
}

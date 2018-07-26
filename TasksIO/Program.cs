using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TasksIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Factory.StartNew<string>(() => GetPosts("https://jsonplaceholder.typicode.com/posts"));
            
            SomethingElse();

            // Here we explicitly do not block the main thread from executing SomethingElse()
            // But same thing implies with the .Result a little bit below. When you type .Result
            // you say that you want to wait for the result to come before continuing.
            //task.Wait();

            try
            {
                Console.WriteLine(task.Result);
            }
            // Every time we try to access the .Result from a task it can throw an AggregateException
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }

        private static void SomethingElse()
        {
            Console.WriteLine("Some other dummy operation.");
        }

        private static string GetPosts(string url)
        {
            using (var client = new HttpClient())
            {
                return client.GetStringAsync(url).Result;
            }
        }
    }
}

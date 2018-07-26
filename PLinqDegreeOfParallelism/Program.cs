using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace PLinqDegreeOfParallelism
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> websites = new List<string>
            {
                "www.apple.com",
                "www.google.com",
                "www.microsoft.com"
            };

            List<PingReply> responses = websites
                                            .AsParallel()
                                            .WithDegreeOfParallelism(websites.Count())
                                            .Select(PingSites())
                                            .ToList();

            foreach (var response in responses)
            {
                Console.WriteLine($@"
                    Response address: {response.Address}
                    Response status: {response.Status}
                    Time taken: {response.RoundtripTime}
                ");
            }

            Console.ReadLine();
        }

        private static Func<string, PingReply> PingSites()
        {
            return website =>
            {
                Ping ping = new Ping();

                return ping.Send(website);
            };
        }
    }
}

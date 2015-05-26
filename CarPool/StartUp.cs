using System;
using Nancy.Hosting.Self;

namespace CarPool
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:1234")))
            {
                host.Start();
                Console.WriteLine("Starting car pool application on port 1234");
                Console.ReadLine();
            }
        }
    }
}
using System;
using Nancy.Hosting.Self;

namespace AuthenticationService
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:9001")))
            {
                host.Start();
                Console.WriteLine("Starting authentication service on port 9001");
                Console.ReadLine();
            }
        }
    }
}
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace fp_web_aula_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
           .UseStartup<Startup>()
           .Build();
        }
    }
}

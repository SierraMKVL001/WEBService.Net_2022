using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaAPI
{
    public class Program
    {
        public static void Main(string[] mklv)
        {
            CreateHostBuilder(mklv).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] mklv) =>
            Host.CreateDefaultBuilder(mklv)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

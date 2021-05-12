using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependecyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())//ba�ka bir ioC kulland�g�m�z� burada tan�ml�yoruz
                .ConfigureContainer<ContainerBuilder>(builder =>//autofac i�in yazd���m�z dosyay� belirtiyoruz.
                {
                    builder.RegisterModule(new AutofacBusinessModule());//.net core alt yap�s�nda ioC alt yap�s� var ancak biz burada bunu kullanca��m�z� belirtiyoruz
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

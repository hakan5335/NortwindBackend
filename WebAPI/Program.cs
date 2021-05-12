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
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())//baþka bir ioC kullandýgýmýzý burada tanýmlýyoruz
                .ConfigureContainer<ContainerBuilder>(builder =>//autofac için yazdýðýmýz dosyayý belirtiyoruz.
                {
                    builder.RegisterModule(new AutofacBusinessModule());//.net core alt yapýsýnda ioC alt yapýsý var ancak biz burada bunu kullancaðýmýzý belirtiyoruz
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

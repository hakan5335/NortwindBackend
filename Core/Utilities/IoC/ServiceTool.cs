using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)//webapi kullanılacak injectionları burada ekliyoruzki tüm katmanlarda kullanabilelim.
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}

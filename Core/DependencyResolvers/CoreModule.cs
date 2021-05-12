using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)//Uygulama seviyesinde bağımlılıklarımızı burada yapıcaz. webapi de yapmıcaz
        {
            serviceCollection.AddMemoryCache();//IMemoryCache  in injeksiyonunu yapıyor.bu new liyor redise geçmek isteğimizde buna gerek kalmıyor. bu .net in IMemoryCache için
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();//Redis eklemek istediğimde buradaki MemoryCacheManager değiştirmek yeterli
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}

﻿using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions//Extension lar static olur
    {
        public static IServiceCollection AddDependecyResolvers(this IServiceCollection serviceCollection,ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
            //Core katmanı da dahil bütün injeksiyonları buradan eklememizi sağlar
        }
    }
}

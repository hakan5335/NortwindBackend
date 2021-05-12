using Castle.DynamicProxy;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();//classin attributlarını oku
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);//Metodun atributlarını oku
            classAttributes.AddRange(methodAttributes);//class ve metod atrıbutlarını listeye koy
            //classAttributes.Add(new LogAspect(typeof(FileLogger)));//Loglama oldugunda direk burda kullanabiliriz. Bütün class ve metodlarda log çalısır durumda olur

            return classAttributes.OrderBy(x => x.Priority).ToArray();//Metod ve class atributlarını(listeye eklenen) sıralıyor
        }
    }
}

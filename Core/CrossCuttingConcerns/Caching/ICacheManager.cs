using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager//Bütün alternatiflerimin interface i olacark redis veya eleasticsearch 
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value,int duration);
        bool IsAdd(string key);//cache de varmı
        void Remove(string key);
        void RemoveByPattern(string pattern);//içinde kelime geçenleri uçur
    }
}

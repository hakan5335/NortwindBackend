using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //T referans tip oldugunu gösterir burada interface veya abstract ta koyabilirsin ,IEntity den türemiş leri gönderebilirsin, new() => olunca da referans tipli IEntityden implemente edilmiş ve new lenebilen leri gönderebilirsin demek oluyor 
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
